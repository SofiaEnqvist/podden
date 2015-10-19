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
        public string feedName { get; set; }
        [XmlElement()]
        public string description { get; set; }
        [XmlElement()]
        public string URL { get; set; }
        [XmlElement()]
        public string Category { get; set; }
        [XmlElement()]
        public List<PodcastEp> PodEp { get; set; }

        internal static Feed mapFeed(SyndicationFeed feed, string category, List<PodcastEp> podcast)
        {
            var feede = new Feed()
            {
                feedName = feed.Title.Text,
                description = feed.Description.Text,
                URL = feed.Links.First().Uri.ToString(),
                Category = category,
                PodEp = podcast
            };
            return feede;
        }
    }
}
