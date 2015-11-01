using RssReader.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;

namespace RssReader.Logic
{
    public static class UpdateInterval
    {
        private static Timer aTimer;
        private static string feedTitle;

        //TODO: Kolla efter backgroundworker på msdn
        //TODO: metoderna här vet jag inte hur man ska kunna köra samtidigt som allt annat händer, det ska hända i bakgrunden alltså. helst Hehe
        
        public static void Timer(int interval, string feed)
        {
            interval = 20000;
            feedTitle = feed;
            aTimer = new System.Timers.Timer(interval);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            searchNewEpisodes(feedTitle);
            Console.WriteLine("vi har sökt efter nya poddar i " + feedTitle + " {0}", e.SignalTime);
            aTimer.Enabled = false;
            //Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            
        }
        //Hämta ut alla xmldocuments intervall, skicka tillbaka en lista på titel och interval
        internal static void getIntervalInt()
        {
            int interval = 0;
            var list = Manage.Man_getTitleListSubscription();
            foreach (var item in list)
            {
                XmlData xml = new XmlData(item);
                var dez = xml.DezerializeFeed();
                interval = dez.Interval * 60000;
                UpdateInterval.Timer(interval, dez.Title);
            }
        }

        private static void searchNewEpisodes(string searchString)
        {
            var xml = new XmlData(searchString);
            var dez = xml.DezerializeFeed();
            var rssPath = dez.URL;
            var lastSubDate = dez.PodEp.OrderByDescending(x => x.PubDate).FirstOrDefault();
            //--------------------------
            var feed = Service.Service.getRssByUri(rssPath);
            var pod = feed.Items.ToList();
            var lastPubDate = pod.OrderByDescending(x => x.PublishDate).FirstOrDefault();

            //Kolla om senaste avsnittet som är sparat har samma pubDate som senaste avsnittet i rssfeeden
            if (lastSubDate.PubDate.ToString("u") != lastPubDate.PublishDate.DateTime.ToString("u"))
            {
                Console.WriteLine("det finn ett nytt avsnitt");
                //Ta det senaste avsnittet och uppdatera feeden.
                Service.Service.DeleteFeed(feed.Title.Text);
                Manage.AddSubManage(rssPath, feed.Title.Text, dez.Category, dez.Interval);
            }
            else
            {
                //gör inget
                Console.WriteLine("inget nytt avsnitt");
            }
        }

    }
}