using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace RssReader.Entity
{



    [Serializable()]
    public class Category
    {
        [XmlElement]
        public string CategoryName { get; set; }
    }
    
}
