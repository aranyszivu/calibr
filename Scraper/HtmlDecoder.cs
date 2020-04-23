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
            #region Node Format
            /*
             * HTML Ad Node Format (2020.04.23.):
             * 
             *  <div class="views-row views-row-[n] views-row-[odd/even]"> [ROOT]
				    <div class="views-field views-field-nothing">
						<span class="field-content">
							<a href="[AD URL]"> [INFOROOT]
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
            #endregion

            HtmlNode infoRoot = adNode.FirstChild.FirstChild.FirstChild;

            string postingUrl = infoRoot.GetAttributeValue("href", null);
            string imageUrl = infoRoot.FirstChild.FirstChild.LastChild.GetAttributeValue("src", null);
            string imageHash = Utilities.GetImageHash(imageUrl);

            return new BO.AdPosting()
            {
                Title       = infoRoot.FirstChild.NextSibling.FirstChild.InnerText,
                Description = infoRoot.FirstChild.NextSibling.LastChild.InnerText,
                PostingURL  = postingUrl,
                ImgUrl      = imageUrl,
                ImgHash     = imageHash,
                Price       = Int32.Parse(infoRoot.FirstChild.LastChild.InnerText.Substring(1)), //All but first '$' character
                //extract city from Ad Url (format: "www.gunpost.ca/[TYPE]/[CATEGORY]/[CITY]/[TITLE-ABBREV]")
                City        = postingUrl.Substring(8).Split('/')[4] //Substring to remove 'https://' from URL
            };
        }
    }
}
