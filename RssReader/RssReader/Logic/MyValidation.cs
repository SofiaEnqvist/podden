﻿using RssReader.Data;
using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Logic
{
    public static class MyValidation
    {
        //Validera om URL verkligen exiserar och om det är en rss..
        public static void doesURLExists(string URL)
        {

        }

        //Validera om podcasten redan prenumerereras på
        public static bool isSubscribedAlredy(string podcast)
        {
            //get title of podcast hämta med streamreader och rulla igenom för att kolla Kanske en if (exists)
                var seria = new XmlData();
                var list = seria.DezerializeFeed();

                return false;
        }
    }
   
}
    
