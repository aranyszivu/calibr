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
        /// <summary>
        /// Given a list of HTML Pages for Search Results, calls assembler for each page.
        /// </summary>
        /// <param name="rawHtmlList">List object of all pages</param>
        /// <returns>List of all Ad Objects</returns>
        public List<BO.AdPosting> GetAdList(List<HtmlDocument> rawHtmlList)
        {
            List<BO.AdPosting> results = GetAdsFromPage(rawHtmlList.First(), true);

            foreach (HtmlDocument doc in rawHtmlList.Skip(1))
            {
                results.AddRange(GetAdsFromPage(doc, false));
            }

            return results;
        }

        /// <summary>
        /// Given an HtmlDocument for a results page, separates the individual Ad Nodes and calls assembler function on each
        /// </summary>
        /// <param name="rawHtml">Raw HTML text for a single page of results</param>
        /// <param name="getFeaturedAds">Inidcates whether or not to retrieve the featured ads duplicated on every page</param>
        /// <returns>List of all AdPosting objects assembled from page</returns>
        private List<BO.AdPosting> GetAdsFromPage(HtmlDocument rawHtml, bool getFeaturedAds)
        {
            // html/body/div[page]/div[columns]/div[content-column]/div[content-inner]/section[main-content]/div[content]/div[block-system-main]/div
            HtmlNode AdListRoot = rawHtml.DocumentNode                              //<html>
                                    .LastChild                                      //  <body>
                                        .SelectSingleNode("div[@id='page']")        //      <div id="page">
                                            .LastChild                              //          <div id = "columns">
                                                .FirstChild                         //              <div id = "content-column">
                                                    .FirstChild                     //                  <div id = "content-inner">
                                                        .FirstChild                 //                      <section id = "main-content">
                                                            .LastChild              //                          <div id = "content">
                                                                .FirstChild         //                              <div id = "block-system-main">
                                                                    .FirstChild;    //                                  <div class = "view ...">

            //root/div[attachment]/div[view]/div[view-content]
            HtmlNode featuredAdList = AdListRoot.FirstChild.FirstChild.FirstChild;
            #region Featured List Node Format
            /*
                <div class="attachment attachment-before">
			        <div class="view view-classified-ads view-id-classified_ads view-display-id-attachment_1">
				        <div class="view-content"> [FEATUREDADLIST node]
					    	<div class="views-row views-row-[N] views-row-[ODD/EVEN] views-row-[FIRST/LAST]">
							    [AD DATA]
						    </div>
					    </div>
					    <div class="view-footer">
						    <hr />
					    </div>
				    </div>
			    </div>
            */
            #endregion

            //root/div[view-content]
            HtmlNode mainAdList = AdListRoot.FirstChild.NextSibling;

            HtmlNode adNode;
            List<BO.AdPosting> results = new List<BO.AdPosting>();

            if (getFeaturedAds) 
            { 
                adNode = featuredAdList.FirstChild;
                while (adNode.NextSibling != null)
                {
                    results.Add(GetAdFromAdNode(adNode));
                    adNode = adNode.NextSibling;
                }
            }
            adNode = mainAdList.FirstChild;
            while(adNode.NextSibling != null)
            {
                results.Add(GetAdFromAdNode(adNode));
                adNode = adNode.NextSibling;
            }

            return results;
        }

        /// <summary>
        /// Assembles AdPosting object from information found in a single Ad HTML Node
        /// </summary>
        /// <param name="adNode">Root HTML Node of a single ad posting</param>
        /// <returns>BusinessLayer.BusinessObjects.Adposting object</returns>
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
                //extract city from Ad Url (format: "[https://]www.gunpost.ca/[TYPE]/[CATEGORY]/[CITY]/[TITLE-ABBREV]")
                City        = postingUrl.Substring(8).Split('/')[4] //Substring to remove 'https://' from URL
            };
        }
    }
}
