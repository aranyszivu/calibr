using System.Collections.Generic;
using System.IO;
using System.Net;
using BL = BusinessLayer;

namespace Scraper
{
    class HtmlGetter
    {
        public List<string> GetHtmlDocuments(BL.SearchParameters parameters)
        {
            List<string> results = new List<string>();
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
        public string GetHtmlDocument(BL.SearchParameters parameters) 
        { 
            return GetHtmlResponse(BuildUrl(parameters));  
        }

        public string BuildUrl(BL.SearchParameters parameters)
        {
            return (new UrlBuilder()).BuildUrl(parameters);
        }

        public string GetHtmlResponse(string strURL)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(strURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if ((response.StatusCode != HttpStatusCode.OK) || !(response.ContentType.StartsWith("text/html"))) { HandleBadResponse(response); }

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);

            return reader.ReadToEnd(); //Response HTML text in String form
        }

        public void HandleBadResponse(HttpWebResponse response) { }
    }
}
