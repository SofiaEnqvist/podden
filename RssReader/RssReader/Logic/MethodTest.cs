using RssReader.Data;
using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;


namespace RssReader.Logic
{
    public static class MethodTest
    {
        //TODO: trim() på namn s .xml inte följer med som substring
        public static List<string> getAllSubs()
        {

            string folderPath = @"C:\temp\";
            List<string> list = new List<string>();
            DirectoryInfo di = new DirectoryInfo(folderPath);
            FileInfo[] rgFiles = di.GetFiles("*.xml");
            foreach (FileInfo fi in rgFiles)
            {
                XmlTextReader reader = new XmlTextReader(fi.Name);
                string namnnamn = fi.Name;

                if (namnnamn.Contains(".xml"))
                {
                    namnnamn = namnnamn.Substring(0, namnnamn.IndexOf(".xml"));
                }
                list.Add(namnnamn);


            }
            return list;
 
        }


        //public static List<PodcastEp> getAllSubscriptions()
        //{
        //     var searchString = "http://rss.acast.com/varvet";
        //    var seria = new XmlData(searchString);
        //    var list = seria.Dezerialize();
        //    return list;
        
        //}

        internal static string getRssDescrition(string searchString)
        {
            var synFeed = SyndicationFeed.Load(XmlReader.Create(searchString));
            return synFeed.Description.Text;
        }




        //Metod som först hämtar lista av podcasten som redan är subscribed, för att sedan lägga till nya avsnitt
        //public static void AddEpService(string searchString)
        //{
        //    var seria = new XmlData(searchString);
        
        //    var list = seria.Dezerialize();
        //    var synFeed = SyndicationFeed.Load(XmlReader.Create(searchString));

        //    foreach (var item in synFeed.Items)
        //    {
        //        var pod = PodcastEp.mapPodcastEp(item);
        //        list.Add(pod);
        //    }

        //    seria.Serialize(list);

        //}
    }
}
