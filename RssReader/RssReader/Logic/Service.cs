﻿using RssReader.Entity;
using System;
using System.Collections.Generic;
using RssReader.Data;
using System.ServiceModel.Syndication;
using System.Xml;

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
                SyndicationFeed feed;
                List<SyndicationItem> listOfItems = new List<SyndicationItem>();
                foreach (SyndicationItem item in synFeed.Items)
                {
                    listOfItems.Add(item);
                }

                feed = new SyndicationFeed(synFeed.Title.Text, synFeed.Description.Text, new Uri(searchString), listOfItems);
                return feed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new SyndicationFeed();
            }

        }

        /// <summary>
        /// Add a new Podcast subscription
        /// </summary>
        /// <param name="feed"></param>
        public static void AddSubService(SyndicationFeed feed, string feedName, string category)
        {
            var seria = new XmlData(feed.Title.Text);
            PodcastEp mappedPodcasts;
            List<PodcastEp> list = new List<PodcastEp>();
            foreach (var item in feed.Items)
            {
                mappedPodcasts = PodcastEp.mapPodcastEp(item);
                list.Add(mappedPodcasts);
            }
            Feed mappedFeed = Feed.mapFeed(feed, feedName, category, list);
            seria.SerializeFeed(mappedFeed);
        }


        /// <summary>
        /// Add a new category
        /// </summary>
        public static void AddCategory(string CategoryName)
        {
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



        /// <summary>
        /// Delete a category
        /// </summary>
        public static void DeleteCategory(string CategoryName)
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

        /// <summary>
        /// Change a category 
        /// </summary>
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

        /// <summary>
        /// Change a feeds category 
        /// </summary>
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

       
        internal static Category GetAllCategory()
        {
            var ser = new XmlCategory();
            var des = ser.DezerializeCategory();
            return des;
        }

        internal static Feed Ser_getSelectedSub(string selectedItem)
        {
            var seria = new XmlData(selectedItem);
            Feed feed = seria.DezerializeFeed();
            return feed;
        }
    }
}
