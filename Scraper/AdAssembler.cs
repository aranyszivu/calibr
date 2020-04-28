using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BO = BusinessLayer.BusinessObjects;

namespace Scraper
{
    class AdAssembler
    {
        public List<string> ConvertAdsToJson(List<BO.AdPosting> adList)
        {
            List<string> JsonList = new List<string>();

            foreach(BO.AdPosting ad in adList) 
            {
                //Note: URI not assigned to each document, only base info
                JsonList.Add(JsonConvert.SerializeObject(ad)); 
            }

            return JsonList;
        }

        public string ConvertAdToJson(BO.AdPosting ad)
        {
            return JsonConvert.SerializeObject(ad);
        }
    }
}
