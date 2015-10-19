using RssReader.Data;
using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Logic
{
    public static class Manage
    {
        /// <summary>
        /// TODO: Put into Repository map
        /// Method that manage the subscription action
        /// </summary>
        /// <param name="searchString"></param>
        public static void AddSubManage(string searchString, string category)
        {
            var list = Service.Service.getRssByUri(searchString);
            Service.Service.AddSubService(list, category);
        }

 

        internal static Feed getSelectedSub(string selectedItem)
        {
            XmlData xml = new XmlData(selectedItem);
           var dezFed = xml.DezerializeFeed();
           return dezFed;
        }

        public static Category fillCb()
        {
            var list = new Category();
            var item = Service.Service.GetCategory();
            return item;
        }
    }
}
