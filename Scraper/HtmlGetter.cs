using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL = BusinessLayer;

namespace Scraper
{
    class HtmlGetter
    {
        public List<HtmlDocument> GetHtmlDocuments(BL.SearchParameters parameters)
        {
            List<HtmlDocument> results = new List<HtmlDocument>();
            foreach (BL.EnumTypes.Websites site in parameters.TargetSites) 
            {
                results.Add(GetHtmlDocument(new BL.SearchParameters 
                                                { 
                                                    TargetSites = new List<BL.EnumTypes.Websites> { site }, 
                                                    Region = parameters.Region,
                                                    City = parameters.City,
                                                    Keywords = parameters.Keywords
                                                }
                                            ));
            }
            return results;
        }
        public HtmlDocument GetHtmlDocument(BL.SearchParameters parameters) 
        { 
            return GetHtmlResponse(BuildUrl(parameters));  
        }

        public string BuildUrl(BL.SearchParameters parameters)
        {
            return UrlBuilder.BuildUrl(parameters);
        }

        public HtmlDocument GetHtmlResponse(string strURL)
        {
            return null;
        }
    }
}
