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
    }
}
