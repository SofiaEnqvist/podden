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
        private string path;
      

        public XmlCategory()

        {
            path = "c:\\Category";
            filepath = "c:\\Category\\Category.xml";
            xmlSerCategory = new XmlSerializer(typeof(Category));
        }

        public void SerializeCategory(Category category)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
            }

            else
            {
                File.Delete(filepath);
                File.Create(filepath).Close();
            }

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
    

