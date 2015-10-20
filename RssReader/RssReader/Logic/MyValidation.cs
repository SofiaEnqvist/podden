using RssReader.Data;
using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssReader.Logic
{
    public static class MyValidation
    {
        //Validera om URL verkligen exiserar och om det är en rss..
        public static void doesURLExists(string URL)
        {
            

        }

        //Validera om podcasten redan prenumerereras på
        public static bool isSubscribedAlredy(string podcast, string podcastTitle)
        {
            //TODO: Lägg till så den loopar och kollar alla feedName, inte bara den första
            //get title of podcast hämta med streamreader och rulla igenom för att kolla Kanske en if (exists)
                var seria = new XmlData(podcastTitle);
                var list = seria.DezerializeFeed();
                bool result = true;

                if (podcast == list.URL)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }


                //if (list.Count == 0)
                //{
                //    result = false;
                //}
                //foreach (Feed item in list)
                //{
                  
                //    if (podcast == item.URL)
                //    {
                //        result = true;
                //    }
                //    else
                //    {
                //        result = false;
                //    }
                //}
                return result;            
        }

        public static bool CategoryAlredy(string CategoryName)
        {
            var ser = new XmlCategory();
            var list = ser.DezerializeCategory();
           
            bool result = false;

            if (list.CategoryName == null)
            {
                result = false;
            }

            else
            {
                for (int i = 0; i < list.CategoryName.Count; i++)
                {
                    if (list.CategoryName[i].Equals(CategoryName))
                    {
                        result = true;
                    }

                }
            }

            return result;
        }
        
    }
   
}
    
