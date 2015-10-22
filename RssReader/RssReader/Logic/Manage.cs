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
            Service.Service.Ser_AddSubscription(list, feedName, category);
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
    }
}
