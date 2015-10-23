﻿using RssReader.Data;
using RssReader.Entity;
using RssReader.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssReader.Logic
{
    public class MyValidation
    {
        

        //Validera om URL verkligen exiserar och om det är en rss..
        public static void doesURLExists(string URL)
        {
            
        }

        //Validera om podcasten redan prenumerereras på
        // Letar igenom alla xml dokument och kollar efter URL. 
        // Kunde inte använda den andra då jag inte hade en titel.
        public static bool isSubscribedAlredy(List<string> TitelAllSub,string URL)
        {
            
                bool result = false;

                for (int i = 0; i < TitelAllSub.Count; i++)
                {
                    var ser = new XmlData(TitelAllSub[i]);
                    var des = ser.DezerializeFeed();
                    
                    if (des.URL.Equals(URL))
                    {
                        result = true;
                        break;
                    }
                }

                return result;
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

        //Validerar om kategorin används.
        public static bool CategoryUse(string CategoryName, List<string> filename)
        {
            bool result = false;
            

           for (int i = 0; i < filename.Count; i++)
           {
               var ser = new XmlData(filename[i]);
               var des = ser.DezerializeFeed();
               if(des.Category.Equals(CategoryName))
               {
                   result = true;
                   break;
               }
           }

           return result;

        }

        public static bool CategoryAlredyExist(string CategoryName)
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
                        break;
                    }

                }
            }

            return result;
        }


        // Denna tittar igenom alla xml och letar om man döpt den till det Feednamnet man försöker döpa till. 
        internal static bool FeedNameExists(string feedName, List<string> AllSub)
        {
            bool result = false;

            for (int i = 0; i < AllSub.Count; i++)
            {
                var seria = new XmlData(AllSub[i]);
                var list = seria.DezerializeFeed();

                if(list.Name.Equals(feedName))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        // Denna kanske inte är nödvändig då vi spara i separata XML. 
        // Gjorde en likadan men som letar igenom alla xml ! 
        internal static bool feedNameExists(string podcastTitle, string feedName)
        {
            var seria = new XmlData(podcastTitle);
            var list = seria.DezerializeFeed();
            bool result = true;

            if (feedName == list.Name)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;

        }
    }
   
}
    
