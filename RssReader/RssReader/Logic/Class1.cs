using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.Data;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RssReader.Logic
{
    public static class Class1
    {
        public static void Mani()
        {
            var searchString = "http://rss.acast.com/varvet";
            var synFeed = SyndicationFeed.Load(XmlReader.Create(searchString));
            foreach (var item in synFeed.Items)
            {
                var title = item.Title.Text;
                
                
            }
        }
    }
}
