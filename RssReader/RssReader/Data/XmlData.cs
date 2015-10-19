using RssReader.Entity;
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
        private string filepath;
        private string dirpath;

        /// <summary>
        /// We want do pass the name of the podcast, example = "Värvet" to create a new xml-document
        /// </summary>
        /// <param name="path">This path is a string that vill create a new xml-document for each new podsubscription or something</param>
        public XmlData(string path)
        {
            dirpath = "c:\\temp";
            filepath = "c:\\temp\\"+path+".xml";
            xmlSerFeed = new XmlSerializer(typeof(Feed));
        }


        /// <summary>
        /// StreamWriter writes a feed, used only when a new subsciption i made
        /// </summary>
        /// <param name="feed"></param>
        public void SerializeFeed(Feed feed)
        {
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }

            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
            }
            using (var sw = new StreamWriter(filepath, true))
            {
                xmlSerFeed.Serialize(sw.BaseStream, feed);
                sw.Dispose();
            }
        }


        /// <summary>
        /// Is used when reading entire feed of a subscribed podcast, this is used beacuse we want all the information about the name of the podcast
        /// and the URL and summary
        /// </summary>
        /// <returns></returns>

        public Feed DezerializeFeed()
        {
            
          
            try
            {
                Feed feed;
              
                using (var sr = new StreamReader(filepath))
                {
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
