using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.Entity
{
    [Serializable()]
       public class PodcastEp
    {
        [XmlElement()]
        public string Title { get; set; }
        [XmlElement()]
        public string Content { get; set; }
        [XmlElement()]
        public DateTime PubDate { get; set; }
        [XmlElement()]
        public string Mp3Link { get; set; }

        internal static PodcastEp mapPodcastEp(SyndicationItem item)
        {
            PodcastEp podEp = new PodcastEp()
            {
                Title = item.Title.Text,
                Content = item.Summary.Text,
                PubDate = item.PublishDate.DateTime,
                Mp3Link = item.Links.FirstOrDefault().Uri.ToString()

            };
            return podEp;
        }
    }
}
