using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.Entity
{
    [Serializable()]
    [XmlRootAttribute("Feed", Namespace = "", IsNullable = true)]
    public class Feed
    {
        [XmlElement()]
        public string Title { get; set; }
        [XmlElement()]
        public string Name { get; set; }
        [XmlElement()]
        public string Description { get; set; }
        [XmlElement()]
        public string URL { get; set; }
        [XmlElement()]
        public string Category { get; set; }
        [XmlElement()]
        public int Interval { get; set; }
        [XmlElement()]
        public List<PodcastEp> PodEp { get; set; }

        internal static Feed mapFeed(SyndicationFeed feed, string feedName, string category, List<PodcastEp> podcast)
        {
            var feede = new Feed()
            {
                Title = feed.Title.Text,
                Name = feedName.ToString(),
                Description = feed.Description.Text,
                URL = feed.Links.First().Uri.ToString(),
                Category = category,
                Interval = 10000,
                PodEp = podcast
            };
            return feede;
        }
    }
}
