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
        public static void AddSubManage(string searchString)
        {
            var list = Service.Service.getRssByUri(searchString);
            Service.Service.AddSubService(list);
        }

        ////Tar emot ett synfeedItem och "omvandlar" till objekt av PodcastEp
       

        //internal static PodcastEp CreatePodEp(SyndicationItem item)
        //{
        //    var podd = new PodcastEp
        //    {
        //        Title = item.Title.Text,
        //        Content = item.Summary.Text,
        //        PubDate = item.PublishDate.DateTime
        //    };
        //    return podd;
        //    throw new NotImplementedException();
        //}

        internal static Feed getSelectedSub(string selectedItem)
        {
            XmlData xml = new XmlData(selectedItem);
           var dezFed = xml.DezerializeFeed();
           return dezFed;
        }
    }
}
