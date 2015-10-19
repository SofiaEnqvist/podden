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
    [XmlRootAttribute("Category", Namespace = "", IsNullable = true)]

    public class Category
    {
        [XmlElement()]
        public List<string> CategoryName { get; set; }
    }


    
}
