using RssReader.Data;
using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using RssReader.Logic.Service;

namespace RssReader.Logic
{
    //Typ en mellanklass mellan design och logiken som sköter xml-hanteringen. 
    public static class Manage
    {
        /// <summary>
        /// TODO: Put into Repository map
        /// Method that manage the subscription action
        /// </summary>
        /// <param name="searchString"></param>
        public static void AddSubManage(string searchString, string feedName, string category)
        {
            var list = Service.Service.getRssByUri(searchString);
            Service.Service.AddSubService(list, feedName, category);
        }



        internal static Feed Man_getSelectedSub(string selectedItem)
        {
         var dezFeed = Service.Service.Ser_getSelectedSub(selectedItem);
         return dezFeed;
        }

        public static Category fillCb()
        {
            var list = new Category();
            var item = Service.Service.GetCategory();
            return item;
        }
    }
}
