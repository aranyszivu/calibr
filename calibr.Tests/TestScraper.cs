using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scraper;

namespace calibr.Tests
{
    [TestClass]
    class TestScraper
    {
        [TestMethod]
        public void TestReplaceMethod()
        {
            string baseStr = "https://[DOMAIN]/ads/";
            string substitutionStr = "www.gunsexchange.ca";
            string expectedStr = "https://www.gunsexchange.ca/ads/";

            UriLoader ldr = new UriLoader();
            ldr.ReplaceField( ref baseStr, "DOMAIN", substitutionStr);
            Assert.AreEqual(expectedStr, baseStr);
        }
    }
}
