using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.Entity
{
    [Serializable()]
    class Category
    {
        [XmlElement()]
        public string CategoryName { get; set; }
    }
}
