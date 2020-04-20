using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class EnumTypes
    {
        public enum Websites
        {
            GunPost,
            FirearmsCanada,
            TownPost
        }
        public enum Regions
        {
            Alberta,
            BritishColumbia,
            Manitoba,
            NewBrunswick,
            NewfoundlandAndLabrador,
            NovaScotia,
            Nunavut,
            NorthwestTerritories,
            Ontario,
            PrinceEdwardIsland,
            Quebec,
            Saskatchewan,
            Yukon
        }
        //TODO: Use cities included by target sites
        public enum Cities
        {
            GTA,
            NationalCapitalRegion
        }
    }
}
