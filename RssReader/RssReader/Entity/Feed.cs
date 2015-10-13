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
    public class Feed
    {
        [XmlElement()]
        public string feedName { get; set; }
        [XmlElement()]
        public string description { get; set; }
        [XmlElement()]
        public string URL { get; set; }
        [XmlElement()]
        public List<PodcastEp> PodList { get; set; }

        internal static Feed mapFeed(SyndicationFeed feed, List<PodcastEp> podcast)
        {
            var feede = new Feed()
            {
                feedName = feed.Title.Text,
                description = feed.Description.Text,
                URL = feed.BaseUri.ToString(),
                PodList = podcast
                //TO DO: Den skickar tillbaka list<podcastep> som tom, vilket ger ett nullexception       
                //Vilket gör att den kraschar, hur ska vi kunna fylla listan?
            };
            return feede;
        }
    }
}
