using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using HtmlAgilityPack;
using BO = BusinessLayer.BusinessObjects;

namespace Scraper
{
    class HtmlDecoder
    {
        public Dictionary<string, BO.AdPosting> GetAdList(List<HtmlDocument> rawHtmlList)
        {
            return null;
        }

        private Dictionary<string, BO.AdPosting> GetAdsFromPage(HtmlDocument rawHtml)
        {
            return null;
        }
    }
}
