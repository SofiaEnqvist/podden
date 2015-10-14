﻿using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.Data
{

    //NOTE TO SELF: vi har två typer av serializer, vilket vi bara behöver använda en
    public class XmlData
    {
        private XmlSerializer xmlSerFeed;
        private XmlSerializer xmlSer;
        private string filepath;

        /// <summary>
        /// We want do pass the name of the podcast, example = "Värvet" to create a new xml-document
        /// </summary>
        /// <param name="path">This path is a string that vill create a new xml-document for each new podsubscription or something</param>
        public XmlData(string path)
        {
            filepath = "c:\\temp\\"+path+".xml";
            xmlSer = new XmlSerializer(typeof(List<PodcastEp>));
            xmlSerFeed = new XmlSerializer(typeof(Feed));
        }


        /// <summary>
        /// StreamWriter writes a feed, used only when a new subsciption i made
        /// </summary>
        /// <param name="feed"></param>
        public void SerializeFeed(Feed feed)
        {
            using (var sw = new StreamWriter(filepath, true))
            {
                xmlSerFeed.Serialize(sw.BaseStream, feed);
                sw.Dispose();
            }
        }

        /// <summary>
        /// StreamWriter that writes list of podcasts, is used most when a new podcastepisode is availible 
        /// </summary>
        /// <param name="list"></param>
        //public void Serialize(List<PodcastEp> list)
        //{
        //    using (var sw = new StreamWriter(filepath, true))
        //    {
        //        xmlSer.Serialize(sw.BaseStream, list);
        //        sw.Dispose();
        //    }
        //}

        /// <summary>
        /// StreamReader reads up a list of pocasts, is used to get one podcastepisode at the time
        /// </summary>
        /// <returns></returns>
        //public List<PodcastEp> Dezerialize()
        //{
        //    try
        //    {
        //        using (var sr = new StreamReader(filepath))
        //        {
        //            var des = xmlSer.Deserialize(sr.BaseStream);
        //            var listOfFeeds = (List<PodcastEp>)des;
        //            sr.Dispose();
        //            return listOfFeeds;

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return new List<PodcastEp>();
        //    }
        //}

        /// <summary>
        /// TODO: Dezerialiseringen fungerar ej, den gillar inte xml-dokumentet
        /// Is used when reading entire feed of a subscribed podcast, this is used beacuse we want all the information about the name of the podcast
        /// and the URL and summary
        /// </summary>
        /// <returns></returns>

        public Feed DezerializeFeed()
        {
            //TODO: När nya filepath är skapat så ska den processen stängas! annars ligger den och körs när podden ska sparas
            //ner och det kraschar
              if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
            }
          
            try
            {
                Feed feed;
              
                using (var sr = new StreamReader(filepath))
                {
                    //return xmlSerFeed.Deserialize(sr) as Feed;
                    var des = xmlSerFeed.Deserialize(sr.BaseStream);
                    feed = (Feed)des;
                    //sr.Dispose();
                    
                }
                return feed;
            }
            catch (Exception)
            {
                return new Feed();
            }
        }
    }

}
