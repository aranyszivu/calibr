using System.Collections.Generic;
using System.IO;
using System.Net;
using BusinessLayer;

namespace Scraper
{
    class HtmlGetter
    {
        /*
        public List<string> GetHtmlDocuments()
        {
            List<string> results = new List<string>();
            for(int i=0; i < System.Enum.GetNames(typeof(EnumTypes.Websites)).Length; i++)
            {
                results.AddRange(GetSearchHtml((EnumTypes.Websites)i));
            }

            return results;
        }
        */

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

        public List<string> GunPostSearch()
        {
            //Get First Results page
            Dictionary<EnumTypes.Regions, string> regionUrls = new Dictionary<EnumTypes.Regions, string>();
            UrlBuilder builder = new UrlBuilder();
            for (int i=0; i < System.Enum.GetNames(typeof(EnumTypes.Regions)).Length; i++)
            {
                builder.GetGunPostRegionalUrl((EnumTypes.Regions) i);
            }

            //Get total # of pages

            //Append HTML Strings of all pages

            return null;
        }

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
