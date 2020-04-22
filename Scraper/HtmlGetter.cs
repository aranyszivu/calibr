using System;
using System.Collections.Generic;
using System.IO;
using BusinessLayer;
using HtmlAgilityPack;

namespace Scraper
{
    class HtmlGetter
    {
       public List<HtmlDocument> GetSearchHtml(EnumTypes.Websites site)
        {
            switch(site)
            {
                case EnumTypes.Websites.GunPost: return GunPostSearch();
                case EnumTypes.Websites.FirearmsCanada: return FirearmsCanadaSearch();
                case EnumTypes.Websites.TownPost: return TownPostSearch();
                default: return null;
            }
        }

        #region GunPost Methods
        public List<HtmlDocument> GunPostSearch()
        {
            List<HtmlDocument> HtmlResults = new List<HtmlDocument>();
            //Get First Results page
            Dictionary<EnumTypes.Regions, string> regionUrls = new Dictionary<EnumTypes.Regions, string>();

            UrlBuilder builder = new UrlBuilder();
            for (int i=0; i < System.Enum.GetNames(typeof(EnumTypes.Regions)).Length; i++)
            {
                regionUrls.Add((EnumTypes.Regions)i, builder.GetGunPostRegionalUrl((EnumTypes.Regions) i));
            }

            //Get Pages from all regions
            foreach (KeyValuePair<EnumTypes.Regions, string> url in regionUrls)
            {
                HtmlDocument firstPageHtml = Utilities.GetHtmlDocument(url.Value);
                HtmlResults.Add(firstPageHtml);

                //Very slow method (pagecrawling), replace with alternate method when possible
                for(int i=1; i < GetNumPagesGunPost(firstPageHtml); i++)
                {
                    HtmlResults.Add(Utilities.GetHtmlDocument(url.Value + "&page=" + i.ToString()));
                }
            }
            return HtmlResults;
        }

        private int GetNumPagesGunPost(HtmlDocument htmlDoc)
        {
            string lastNode = htmlDoc.DocumentNode.SelectSingleNode("//a[contains(concat(' ',normalize-space(@title),' '),' Go to last page ')]").GetAttributeValue("href",null);
            string parse = lastNode.Split('=')[1];
            return Int32.Parse(parse);
        }

        #endregion

        public List<HtmlDocument> FirearmsCanadaSearch()
        {
            return null;
        }

        public List<HtmlDocument> TownPostSearch()
        {
            return null;
        }
    }
}
