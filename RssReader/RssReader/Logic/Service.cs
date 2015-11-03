using RssReader.Entity;
using System;
using System.Linq;
using System.Collections.Generic;
using RssReader.Data;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;

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
            try
            {
                var synFeed = SyndicationFeed.Load(XmlReader.Create(searchString));
                List<SyndicationItem> listOfItems = new List<SyndicationItem>();
                foreach (SyndicationItem item in synFeed.Items)
                {
                    listOfItems.Add(item);
                }

                SyndicationFeed feed = new SyndicationFeed(synFeed.Title.Text, synFeed.Description.Text, new Uri(searchString), listOfItems);
                return feed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new SyndicationFeed();
            }

        }

        internal static void Ser_Add(SyndicationFeed feed, string feedName, string category, int interval)
        {
            try
            {
                var seria = new XmlData(feed.Title.Text);
                List<PodcastEp> list = new List<PodcastEp>();
                foreach (var item in feed.Items)
                {
                    PodcastEp mappedPodcasts = PodcastEp.mapPodcastEp(item);
                    list.Add(mappedPodcasts);
                }
                Feed mappedFeed = Feed.mapFeed(feed, feedName, category, interval, list);
                seria.SerializeFeed(mappedFeed);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        internal static void Ser_Play(SyndicationFeed feed, string feedName, string category, int interval, string EpName)
        {
            

            try
            {
                var seria = new XmlData(feed.Title.Text);
                List<PodcastEp> list = new List<PodcastEp>();
                
              
                foreach (SyndicationItem item in feed.Items)
                {
                    if (EpName == item.Links.First().Uri.ToString())
                    {
                        PodcastEp mappedPodcasts = PodcastEp.mapPodcastEp(item, 1);
                        list.Add(mappedPodcasts);
                    }
                    else
                    {
                        PodcastEp mappedPodcasts = PodcastEp.mapPodcastEp(item);
                        list.Add(mappedPodcasts);
                    }
                    
                    
                }

                Feed mappedFeed = Feed.mapFeed(feed, feedName, category, interval, list);
                seria.SerializeFeed(mappedFeed);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Ser_Play(string FeedName, string EpName)
        {
            var seria = new XmlData(FeedName);
            Feed Feed = seria.DezerializeFeed();
            SyndicationFeed list = getRssByUri(Feed.URL);
            Ser_Play(list, Feed.Name, Feed.Category, Feed.Interval, EpName);
        }


        public static void Ser_AddCategory(string CategoryName)
        {
            try {
                var ser = new XmlCategory();
                var des = ser.DezerializeCategory();
                List<string> lista = new List<string>();
                Category c = new Category();

                if (des.CategoryName == null)
                {
                    lista.Add(CategoryName);
                    c.CategoryName = lista;
                    ser.SerializeCategory(c);
                }

                else
                {
                    lista = des.CategoryName;
                    lista.Add(CategoryName);
                    c.CategoryName = lista;
                    ser.SerializeCategory(c);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public static void DeleteCategory(string CategoryName)
        {
            try
            {
                var ser = new XmlCategory();
                var des = ser.DezerializeCategory();
                Category c = new Category();
                List<string> list = new List<string>();

                for (int i = 0; i < des.CategoryName.Count; i++)
                {
                    if (des.CategoryName[i] != CategoryName)
                    {
                        list.Add(des.CategoryName[i]);
                    }
                }

                c.CategoryName = list;
                ser.SerializeCategory(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

        public static void ChangeCategory(string name, string newName)
        {
            var ser = new XmlCategory();
            Category c = ser.DezerializeCategory();

            for (int i = 0; i < c.CategoryName.Count; i++)
            {
                if (c.CategoryName[i].Equals(name))
                {
                    c.CategoryName[i] = newName;
                }
            }

            ser.SerializeCategory(c);
        }


        public static void ChangeFeed(List<string> FeedName, string NewCategory)
        {
            for (int i = 0; i < FeedName.Count; i++)
            {
                var ser = new XmlData(FeedName[i]);
                Feed des = ser.DezerializeFeed();

                des.Category = NewCategory;
                ser.SerializeFeed(des);
            }        
        }

        /// <summary>
        /// Change a feed.
        /// </summary>
        public static void ChangeFeed(string URL, string FeedName, string Category, int inter)
        {
            SyndicationFeed feed = getRssByUri(URL);
            Ser_Add(feed, FeedName, Category, inter);          
        }

        public static void DeleteFeed(string FeedName)
        {
            string file = "c:\\temp\\" + FeedName + ".xml";
            File.Delete(file);
        }
       

        internal static Category GetAllCategory()
        {
            var ser = new XmlCategory();
            var des = ser.DezerializeCategory();
            return des;
        }


        internal static List<string> GetAllCategorysFeed(List<string> FeedTitels, string CategoryName)
        {
            List<string> feedName = new List<string>();

            for (int i = 0; i < FeedTitels.Count; i++)
            {
                var ser = new XmlData(FeedTitels[i]);
                var des = ser.DezerializeFeed();

                if (des.Category.Equals(CategoryName))
                {
                    feedName.Add(des.Title);
                }
            }
            return feedName;
        }


        internal static Feed Ser_getSelectedSub(string selectedItem)
        {
            try
            {
                var seria = new XmlData(selectedItem);
                Feed feed = seria.DezerializeFeed();
                return feed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Feed();
            }
        }


        internal static List<string> Ser_getTitleAllSubs()
        {
            try
            {
                string folderPath = @"C:\temp\";
                List<string> list = new List<string>();
                DirectoryInfo di = new DirectoryInfo(folderPath);
                FileInfo[] rgFiles = di.GetFiles("*.xml");
                foreach (FileInfo fi in rgFiles)
                {
                    XmlTextReader reader = new XmlTextReader(fi.Name);
                    string namnnamn = fi.Name;

                    if (namnnamn.Contains(".xml"))
                    {
                        namnnamn = namnnamn.Substring(0, namnnamn.IndexOf(".xml"));
                    }
                    list.Add(namnnamn);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<string>();
            }
        }
    }
}
