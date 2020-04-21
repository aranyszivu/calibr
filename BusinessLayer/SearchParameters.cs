using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SearchParameters
    {
        public List<EnumTypes.Websites> TargetSites;
        public EnumTypes.Regions? Region;
        public EnumTypes.Cities? City;
        public string Keywords;
    }
}
