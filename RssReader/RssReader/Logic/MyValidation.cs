using RssReader.Data;
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

        /// <summary>
        /// Check if the podcast is alredy subscribed, returns bool, if it is subscribed alredy it returns "true"
        /// </summary>
        /// <param name="podcast"></param>
        /// <param name="podcastTitle"></param>
        /// <returns>bool</returns>
        public static bool isSubscribedAlredy(string podcast, string podcastTitle)
        {
                var seria = new XmlData(podcastTitle);
                var finns = seria.DezerializeFeed();
                bool result = true;
                if (finns.URL == null)
                {
                    result = false;
                }
                else if (podcast == finns.URL)
                {
                    result = true;
                }
                return result;
                
        }
    }
   
}
    
