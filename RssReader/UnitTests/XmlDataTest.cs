using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RssReader.Data;
using RssReader.Entity;
using System.Collections.Generic;


namespace UnitTests
{
    [TestClass]
    public class XmlDataTest
    {
        [TestMethod]
        public void TestWriter()
        {
            var podlist = new List<PodcastEp>();
            var seria = new XmlData("");
            var list = seria.DezerializeFeed();
            list = new Feed
            {
                Category = "Träning",
                Description = "En bra podcast",
                Interval = 4,
                Name = "Fredagspodden",
                Title = "PodFredag",
                URL = "test.com.url",
                PodEp = podlist
            };
            seria.SerializeFeed(list);
        }
        [TestMethod]
        public void TestReader()
        {
            var seria = new XmlData("Värvet");
            var feed = seria.DezerializeFeed();
            Assert.AreEqual("Värvet", feed.Title);
        }

    }
}
