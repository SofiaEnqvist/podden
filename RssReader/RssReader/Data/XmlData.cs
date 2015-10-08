using RssReader.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.Data
{
    public class XmlData
    {
        private XmlSerializer xmlSer;
        private string filepath;

        public XmlData()
        {
            filepath = "c:\\temp\\Poddis.xml";
            xmlSer = new XmlSerializer(typeof(List<PodcastEp>));
        }

        public void Serialize(List<PodcastEp> lista)
        {
            using (var sw = new StreamWriter(filepath, true))
            {
                xmlSer.Serialize(sw.BaseStream, lista);
                sw.Dispose();
            }
        }
        public List<PodcastEp> Dezerialize()
        {
            try
            {
                using (var sr = new StreamReader(filepath))
                {
                    var des = xmlSer.Deserialize(sr.BaseStream);
                    var listOfFeeds = (List<PodcastEp>)des;
                    sr.Dispose();
                    return listOfFeeds;

                }
            }
            catch (Exception)
            {
                return new List<PodcastEp>();
            }
        }
    }

}
