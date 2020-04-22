using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using HtmlAgilityPack;
using BO = BusinessLayer.BusinessObjects;

namespace Scraper
{
    class HtmlDecoder
    {
        public Dictionary<string, BO.AdPosting> GetAdList(List<HtmlDocument> rawHtmlList)
        {
            return null;
        }

        private Dictionary<string, BO.AdPosting> GetAdsFromPage(HtmlDocument rawHtml)
        {
            return null;
        }

        private BO.AdPosting GetAdFromAdNode(HtmlNode adNode)
        {
            /*
             * HTML Ad Node Format:
             * 
             *  <div class="views-row views-row-[n] views-row-[odd/even]">
				    <div class="views-field views-field-nothing">
						<span class="field-content">
							<a href="[AD URL]">
								<div class="left">
									<div class="image">
										<div class="urgent"/>
								        <img class="image-style-classified" src="[IMAGE URL]" width="768" height="516" alt="[ALT TITLE]" title="[TITLE]" />
									</div>
								<div class="price For sale ">$[PRICE]</div>
								</div>
								<div class="right">
								    <h2 class="For sale " >[TITLE]</h2>
									<div class="postdate">Apr 20, 2020 </div>
									<div class="body">[DESCRIPTION]</div>
								</div>
								<div class="clearfloat"/>
							</a>
						</span>
					</div>
				</div>
             * 
             */

            string title;
            string description;
            string postingUrl;
            string imageUrl;
            string imageHash = Utilities.GetImageHash(imageUrl);
            int price;
            string city;
            string region;


            BO.AdPosting newAd = new BO.AdPosting();



            return newAd;
        }
    }
}
