using RssReader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.Data;
using System.ServiceModel.Syndication;
using System.Xml;
using System.ComponentModel;

namespace RssReader.Logic.Service
{
    //Klassen används för metoder som lägger till, tar bort, eller ändrar i xml
    public static class Service
    {
        /// <summary>
        /// Search for the URL from the searchbox and gets the RSS 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>Syndicationfeed</returns>
        public static SyndicationFeed getRssByUri(string searchString)
        {
            var synFeed = SyndicationFeed.Load(XmlReader.Create(searchString));
            SyndicationFeed feed;
            List<SyndicationItem> listOfItems = new List<SyndicationItem>();
            foreach (SyndicationItem item in synFeed.Items)
            {
                listOfItems.Add(item);
            }
            feed = new SyndicationFeed(synFeed.Title.Text, synFeed.Description.Text, new Uri(searchString), listOfItems);
            return feed;
        }


        /// <summary>
        /// Add a new Podcast subscription
        /// </summary>
        /// <param name="feed"></param>
        public static void AddSubService(SyndicationFeed feed)
        {
            var seria = new XmlData();
            PodcastEp mappedPodcasts;
            List<PodcastEp> list = new List<PodcastEp>();
            foreach (var item in feed.Items)
            {
                mappedPodcasts = PodcastEp.mapPodcastEp(item);
                list.Add(mappedPodcasts);
            }
            Feed mappedFeed = Feed.mapFeed(feed, list);
            seria.SerializeFeed(mappedFeed);
        }
    }
}
