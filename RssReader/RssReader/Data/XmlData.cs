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
        private string searchPath;

        public XmlData()
        {
            xmlSer = new XmlSerializer(typeof(List<string>));
        }

        public void Serialize(List<string> lista)
        {
            using (var sw = new StreamWriter(searchPath, true))
            {
                xmlSer.Serialize(sw.BaseStream, lista);
                sw.Dispose();
            }
        }
        public List<string> Dezerialize()
        {
            try
            {
                using (var sr = new StreamReader(searchPath))
                {
                    var des = xmlSer.Deserialize(sr.BaseStream);
                    var listOfFeeds = (List<string>)des;
                    sr.Dispose();
                    return listOfFeeds;

                }
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
    }

}
