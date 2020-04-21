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
            return "";
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
