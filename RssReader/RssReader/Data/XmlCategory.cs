using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace RssReader.Data
{
    public class XmlCategory
    {
        private XmlSerializer xmlSerCategory;
        private string filepath;
        
        // Skapa mapppen. 

        public XmlCategory()

        {
            filepath = "c:\\temp\\Category.xml";
            xmlSerCategory = new XmlSerializer(typeof(Category));
        }



        public void SerializeCategory(Category category)
        {

            using (var sw = new StreamWriter(filepath, true))
            {
                xmlSerCategory.Serialize(sw.BaseStream, category);
                sw.Dispose();
            }

        }

        public Category DezerializeCategory()
        {
            try
            {
               Category category;

                using (var sr = new StreamReader(filepath))
                {
                    var des = xmlSerCategory.Deserialize(sr.BaseStream);
                    category = (Category)des;
                }

                return category;
            }
            catch (Exception)
            {
                return new Category();
            }

        }

        
    }
    
}
    

