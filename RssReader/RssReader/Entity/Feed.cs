﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Entity
{
    public class Feed
    {
        public string feedName { get; set; }
        public string description { get; set; }
        public string URL { get; set; }
        public BindingList<PodcastEp> PodList { get; set; }

        internal static Feed mapFeed(SyndicationFeed feed, BindingList<PodcastEp> podcast)
        {
            var feede = new Feed()
            {
                feedName = feed.Title.Text,
                description = feed.Description.Text,
                URL = " ",
                PodList = podcast
                //TO DO: Den skickar tillbaka list<podcastep> som tom, vilket ger ett nullexception       
                //Vilket gör att den kraschar, hur ska vi kunna fylla listan?
            };
            return feede;
        }
    }
}