using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using BusinessLayer;

namespace Scraper
{
    class UrlBuilder
    {
        private ResourceManager manager;

        

        public string GetGunPostRegionalUrl(EnumTypes.Regions region)
        {
            manager = new ResourceManager("Scraper.Resources.GunpostResources", Assembly.GetExecutingAssembly());

            string strURL= manager.GetString("urifGunPostRegion");
            Utilities.AddUrlParameter(ref strURL, "DOMAIN", manager.GetString("dmnGunPost"));
            switch (region)
            {
                case EnumTypes.Regions.Alberta:                 Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnAlberta"));            break;
                case EnumTypes.Regions.BritishColumbia:         Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnBritishColumbia"));    break;
                case EnumTypes.Regions.Manitoba:                Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnManitoba"));           break;
                case EnumTypes.Regions.NewBrunswick:            Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnNewBrunswick"));       break;
                case EnumTypes.Regions.NewfoundlandAndLabrador: Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnNewfoundland"));       break;
                case EnumTypes.Regions.NorthwestTerritories:
                case EnumTypes.Regions.Nunavut:
                case EnumTypes.Regions.Yukon:                   Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnTerritories"));        break;
                case EnumTypes.Regions.NovaScotia:              Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnNovaScotia"));         break;
                case EnumTypes.Regions.Ontario:                 Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnOntario"));            break;
                case EnumTypes.Regions.PrinceEdwardIsland:      Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnPrinceEdwardIsland")); break;
                case EnumTypes.Regions.Quebec:                  Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnQuebec"));             break;
                case EnumTypes.Regions.Saskatchewan:            Utilities.AddUrlParameter(ref strURL, "REGION", manager.GetString("rgnSaskatchewan"));       break;
                default: throw new NotImplementedException("Unsupported Region!");
            }
            return strURL;
        }

        private string AssembleFirearmsCanadaUrl(SearchParameters parameters)
        {
            return "";
        }
        private string AssembleTownpostUrl(SearchParameters parameters)
        {
            return "";
        }
    }
}
