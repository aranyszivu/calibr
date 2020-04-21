using System.Collections.Generic;
using System.IO;
using System.Net;
using BusinessLayer;

namespace Scraper
{
    class HtmlGetter
    {
       public List<string> GetSearchHtml(EnumTypes.Websites site)
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
        public List<string> GunPostSearch()
        {
            List<string> HtmlResults = new List<string>();
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
                string firstPageHtml = Utilities.GetPageHtml(url.Value);
                HtmlResults.Add(firstPageHtml);

                //Very slow method (pagecrawling), replace with alternate method when possible
                for(int i=1; i < GetNumPagesGunPost(firstPageHtml); i++)
                {
                    HtmlResults.Add(Utilities.GetPageHtml(url.Value + "&page=" + i.ToString()));
                }
            }
            return HtmlResults;
        }

        private int GetNumPagesGunPost(string htmlText)
        {
            return 1;
        }

        #endregion

        public List<string> FirearmsCanadaSearch()
        {
            return null;
        }

        public List<string> TownPostSearch()
        {
            return null;
        }
    }
}
