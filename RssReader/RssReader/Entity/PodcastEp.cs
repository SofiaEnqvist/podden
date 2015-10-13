﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Entity
{
    public class PodcastEp
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PubDate { get; set; }

        internal static PodcastEp mapPodcastEp(SyndicationItem item)
        {
            PodcastEp podEp = new PodcastEp()
            {
                Title = item.Title.Text,
                Content = item.Summary.Text,
                PubDate = item.PublishDate.DateTime
            };
            return podEp;
        }
    }
}