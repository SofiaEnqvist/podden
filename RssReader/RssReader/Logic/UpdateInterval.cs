using RssReader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RssReader.Logic
{
    public static class UpdateInterval
    {
        private static Timer aTimer;


        //1. hur ska vi få fram hur alla xmldokument ska ha en update interval, ett eget xml?
        // 

        public static void Timer()
        {
            searchNewEpisodes("Värvet");
            //aTimer = new System.Timers.Timer(2000);
            //aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;
        }

        //Syndicationfeed.load på varje subscription. Om det finns ett nytt avsnitt, jämfört med senaste publicationdate, så sk det läggas till
        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            
        }

        private static void loadFeed(string searchString)
        {

        }
        // TODO: Avsnittet som sparas i subscription behöver sparas med en mer precis datetime,
        //Som det är nu så sparas den i hela timmar, den avrundar uppåt, gör nått åt det.
        private static void searchNewEpisodes(string searchString)
        {
            searchString = "Värvet";
            var xml = new XmlData(searchString);
            var dez = xml.DezerializeFeed();
            var rssPath = dez.URL;
            
            var lastSubDate = dez.PodEp.OrderByDescending(x => x.PubDate).FirstOrDefault();
            Console.WriteLine(lastSubDate.PubDate + lastSubDate.Title);
            //--------------------------
           var feed = Service.Service.getRssByUri(rssPath);
           var pod = feed.Items.ToList();
           var lastPubDate = pod.OrderByDescending(x => x.PublishDate).FirstOrDefault();
           Console.WriteLine(lastPubDate.PublishDate + "Nytt avsnitt ? " + lastPubDate.Title.Text );
        }
    }
}
