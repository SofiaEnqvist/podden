using RssReader.Data;
using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace RssReader.Logic
{
    public static class MethodTest
    {


        public static List<PodcastEp> getAllSubscriptions()
        {
             var searchString = "http://rss.acast.com/varvet";
            var seria = new XmlData(searchString);
            var list = seria.Dezerialize();
            return list;
        }

        internal static string getRss(string searchString)
        {
            var synFeed = SyndicationFeed.Load(XmlReader.Create(searchString));
            return synFeed.Description.Text;
        }




        //Metod som först hämtar lista av podcasten som redan är subscribed, för att sedan lägga till nya avsnitt
        public static void AddEpService(string searchString)
        {
            var seria = new XmlData(searchString);
        
            var list = seria.Dezerialize();
            var synFeed = SyndicationFeed.Load(XmlReader.Create(searchString));

            foreach (var item in synFeed.Items)
            {
                var pod = PodcastEp.mapPodcastEp(item);
                list.Add(pod);
            }

            seria.Serialize(list);

        }
    }
}
