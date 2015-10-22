using RssReader.Data;
using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using RssReader.Logic.Service;
using System.IO;
using System.Xml;

namespace RssReader.Logic
{
    //Typ en mellanklass mellan design och logiken som dirigerar vad som ska hända vid olika events. Eg kanske lite överflödig i detta projekt men 
    //tanken är god... 
    public static class Manage
    {
        /// <summary>
        /// TODO: Put into Repository map
        /// Method that manage the subscription action
        /// </summary>
        /// <param name="searchString"></param>
        internal static void AddSubManage(string searchString, string feedName, string category)
        {
            var list = Service.Service.getRssByUri(searchString);
            Service.Service.Ser_Add(list, feedName, category);
        }


        internal static Feed Man_getSelectedSub(string selectedItem)
        {
            return Service.Service.Ser_getSelectedSub(selectedItem);
        }


        internal static Category fillCb()
        {
            return Service.Service.GetAllCategory();
        }


        internal static List<string> Man_getTitleListSubscription()
        {
            return Service.Service.Ser_getTitleAllSubs();
        }


        //Hämta alla xmldokument
        internal static List<string> Man_GetSelFeed(object selected)
        {
            var path = "c:\\temp";
            var feedlist = Man_getDirectory(path);
            var categoryList = new List<string>();
            foreach (var feed in feedlist)
            {
                if (feed.Category == selected.ToString())
                {
                    categoryList.Add(feed.Title);
                }
            }
            return categoryList;
        }


        public static List<Feed> Man_getDirectory(string path)
        {
            string[] fileEntries = Directory.GetFiles(path);
            var feedllist = new List<Feed>();
            foreach (var fileName in fileEntries)
            {
                var feed = Man_ProcessFile(fileName);
                feedllist.Add(feed);
            }
            return feedllist;
        }

        public static Feed Man_ProcessFile(string filePath)
        {
            string path = filePath.Substring(8);
            string donePath = path.Substring(0, path.IndexOf(".xml"));
            var feed = Service.Service.Ser_getSelectedSub(donePath);
            return feed;
        }
    }
}
