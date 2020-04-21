using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using BL = BusinessLayer;

namespace Scraper
{
    class UrlBuilder
    {
        private ResourceManager manager;

        public string BuildUrl(BusinessLayer.SearchParameters parameters)
        {
            switch(parameters.TargetSites[0])
            {
                case BL.EnumTypes.Websites.GunPost:         return AssembleGunPostUrl(parameters);
                case BL.EnumTypes.Websites.FirearmsCanada:  return AssembleFirearmsCanadaUrl(parameters);
                case BL.EnumTypes.Websites.TownPost:        return AssembleTownpostUrl(parameters);
                default: return null;
            }
        }

        private string AssembleGunPostUrl(BL.SearchParameters parameters)
        {
            manager = new ResourceManager("Scraper.Resources.GunpostResources", Assembly.GetExecutingAssembly());

            string strURL;

            if(parameters.Keywords != null) //Cant search categories and keywords concurrently on gunpost, for whatever reason
            {
                strURL = manager.GetString("urifGunPostSearch");
                Utilities.AddUrlParameter(ref strURL, "DOMAIN", manager.GetString("dmnGunPost"));
                Utilities.AddUrlParameter(ref strURL, "KEYWORDS", parameters.Keywords);
            }
            else
            {
                strURL = manager.GetString("urifGunPostFilter");
                Utilities.AddUrlParameter(ref strURL, "DOMAIN", manager.GetString("dmnGunPost"));

                if (parameters.City == null && parameters.Region != null)
                {
                    Utilities.AddUrlParameter(ref strURL, "FILTERS", manager.GetString("urifRegion"));
                    Utilities.AddUrlParameter(ref strURL, "REGION", parameters.Region.ToString());
                }
                else if (parameters.City != null && parameters.Region == null)
                {
                    Utilities.AddUrlParameter(ref strURL, "FILTERS", manager.GetString("urifCity"));
                    Utilities.AddUrlParameter(ref strURL, "CITY", parameters.City.ToString());
                }
            }

            return strURL;
        }

        private string AssembleFirearmsCanadaUrl(BL.SearchParameters parameters)
        {
            return "";
        }
        private string AssembleTownpostUrl(BL.SearchParameters parameters)
        {
            return "";
        }
    }
}
