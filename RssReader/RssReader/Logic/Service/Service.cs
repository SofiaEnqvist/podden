using RssReader.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.Data;

namespace RssReader.Logic.Service
{
    public static class Service
    {

        public static void AddPodds(List<PodcastEp> newPodList)
        {
            try
            {
                var seria = new XmlData();
                seria.Serialize(newPodList);

            }
        catch(Exception){
        }
        }
    }
}
