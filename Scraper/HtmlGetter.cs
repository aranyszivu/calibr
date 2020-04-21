using System.Collections.Generic;
using System.IO;
using System.Net;
using BL = BusinessLayer;

namespace Scraper
{
    class HtmlGetter
    {
        public List<string> GetHtmlDocuments()
        {
            List<string> results = new List<string>();
            for(int i=0; i < System.Enum.GetNames(typeof(BL.EnumTypes.Websites)).Length; i++)
            {

            }

            return results;
        }
    }
}
