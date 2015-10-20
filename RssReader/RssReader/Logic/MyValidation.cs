using RssReader.Data;
using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.IO;
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

        //validerar om kategorin som vill tas bort används.
        public static List<string> CategoryUse(string CategoryName)
        {
        
            //Får en lista av aktuella filenamn.
            List<string> FileName = MethodTest.getAllSubs();

            //Läser av varje filerna och letar efter kategorinamnet.
            // Samlar alla feednamn i en lista(feedname)som har den valda kategorin. 
            //skickar tillbaka listan, om listan är tom kanske de skiter sig?

            
            List<string> feedName = new List<string>();
            

            for (int i = 0; i < FileName.Count; i++)
            {
                var ser = new XmlData(FileName[i]);
                var des = ser.DezerializeFeed();
                
                if(des.Category.Equals(CategoryName))
                {
                    feedName.Add(des.feedName);
                }     
            }

            return feedName;

        }

        // validerar om kategorin finns 
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
    
