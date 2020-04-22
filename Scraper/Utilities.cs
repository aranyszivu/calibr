using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Scraper
{
    static class Utilities
    {
        public static bool AddUrlParameter(ref string baseStr, string field, string parameter)
        {
            //Search Base String for field in format *[FIELD]*
            for (int i = 0; i < baseStr.Length; i++)
            {
                if (baseStr[i] == '[')
                {
                    string candidate = "";
                    int j = i;
                    while (baseStr[j] + 1 != ']')
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

        /// <summary>
        /// Gets an MD5 Hash string of the image at a supplied URL
        /// </summary>
        /// <param name="url">URL of image</param>
        /// <returns>MD5 Hash of image</returns>
        public static string GetImageHash(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream rawFS = response.GetResponseStream())
            using (MD5 hasher = MD5.Create())
            {
                return BitConverter.ToString(hasher.ComputeHash(rawFS)).Replace("-", string.Empty);
            }
        }

        public static HtmlDocument GetPageHtml(string strUrl)
        {
            HtmlWeb web = new HtmlWeb();
            return web.Load(strUrl);
        }
    }
}
