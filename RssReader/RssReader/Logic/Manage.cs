using RssReader.Entities;
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
        //Tar emot ett synfeedItem och "omvandlar" till objekt av PodcastEp
       

        internal static PodcastEp CreatePodEp(SyndicationItem item)
        {
            var podd = new PodcastEp
            {
                Title = item.Title.Text,
                Content = item.Summary.Text,
                PubDate = item.PublishDate.DateTime
            };
            return podd;
            throw new NotImplementedException();
        }
    }
}
