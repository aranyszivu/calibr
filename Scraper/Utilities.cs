using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    static class Utilities
    {
        public static bool AddUrlParameter(ref string baseStr, string field, string parameter)
        {
            //Search Base String for field in format *[FIELD]*
            for(int i=0; i<baseStr.Length; i++)
            {
                if(baseStr[i] == '[')
                {
                    string candidate = "";
                    int j = i;
                    while (baseStr[j]+1 != ']')
                    {
                        candidate += baseStr[j++];
                        if (candidate == field)
                        {
                            //Replace field by sandwiching head/parameter/tail
                            baseStr = baseStr.Substring(0, i) + parameter + baseStr.Substring(j + 2, baseStr.Length - (j + 2));
                            return true;
                        }
                    }
                    i = j + 2; //skips already checked field and tail ']'
                }
            }
            return false;
        }
    }
}
