using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.Entity
{
    [Serializable()]
    [XmlRoot]
    public class Subscription
    {

    [XmlElement]
        public List<Feed> subscribedFeed { get; set; }
    }
}
