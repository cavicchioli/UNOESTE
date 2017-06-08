using HtmlAgilityPack;
using Newtonsoft.Json;
using prjChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjChallenge.Controllers
{
    [ValidateInput(false)]
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ViewResult ExtractData()
        {
            //LOAD SITE
            string url = Request.Form["url"].ToString();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);

            //CREATE MY MODEL
            Hotel hotel = new Hotel();
            hotel.Rooms = new List<Room>();
            hotel.AlternativeHotels = new List<Hotel>();

            //Finding Hotel Name
            hotel.Name = document.GetElementbyId("hp_hotel_name").InnerText.Replace("\n", ""); 

            //Finding Hotel Address
            hotel.Address = document.DocumentNode.SelectNodes("//*[contains(@class,'hp_address_subtitle')]").ToList().FirstOrDefault().InnerHtml.Replace("\n", "");

            //Finding Hotel Rating (Stars)
            HtmlNode ratingNode = document.DocumentNode.SelectNodes("//*[contains(@class,'hp__hotel_ratings__stars')]").Descendants("svg").Where(d => d.Attributes.Contains("class")).FirstOrDefault();
            if(ratingNode != null)
            {
                string ratingClass = ratingNode.Attributes.Where(d => d.Value.Contains("-sprite-ratings_")).FirstOrDefault().Value.ToString();
                hotel.Stars = ratingClass.Split('_')[2];
            }
            
            //Finding review points
            string reviewPoints = document.DocumentNode.SelectNodes("//*[contains(@class,'review-score-badge')]").ToList().FirstOrDefault().InnerHtml;
            hotel.ReviewPoints = reviewPoints.Replace("<span class=\"review-score__decimal-separator\">", "").Replace("</span>", "").Replace("\n", "");

            //Finding total number of reviews
            string totalReviews = document.DocumentNode.SelectNodes("//*[contains(@class,'review-score-widget__subtext')]").ToList().FirstOrDefault().InnerHtml;
            hotel.TotalReviews = totalReviews.Replace(" ", "|").Split('|')[0].Replace("\n", "");

            //Finding description
            IEnumerable<HtmlNode> summary = document.DocumentNode.SelectNodes("//*[contains(@id,'summary')]").Descendants("p");
            foreach (HtmlNode item in summary.Skip(2))
            {
                hotel.Description+=item.InnerText.Replace("\n","")+" ";
            }

            //Finding rooms
            IEnumerable<HtmlNode> rooms = document.DocumentNode.SelectNodes("//*[contains(@id,'maxotel_rooms')]").Descendants("tr");
            //.Where(d => d.Name.Contains("tr"));


            Room r;
            foreach (HtmlNode item in rooms.Skip(1))
            {
                r = new Room();

                //Selecting the Room description
                r.Description = item.ChildNodes.Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("ftd")).FirstOrDefault().InnerHtml.Replace("\n", "");

                //Finding the max adults allowed in the room
                HtmlNode adults = item.Element("td").Element("span").Descendants("span").Where(d => d.Attributes["class"].Value.Contains("occupancy_adults")).FirstOrDefault();
                if(adults==null)
                    adults = item.Element("td").Descendants("span").Where(d => d.Attributes["class"].Value.Contains("occupancy_adults")).FirstOrDefault();
                 
                if(adults!=null)
                    r.MaxAdults = adults.Descendants("i").Where(d => d.Attributes["class"].Value.Contains("bicon-occupancy")).Count().ToString();

                //Finding the max childrens allowed in the room
                HtmlNode childs = item.Element("td").Element("span").Descendants("span").Where(d => d.Attributes["class"].Value.Contains("occupancy_children")).FirstOrDefault();
                if (childs == null)
                    childs = item.Element("td").Descendants("span").Where(d => d.Attributes["class"].Value.Contains("occupancy_children")).FirstOrDefault();

                if (childs != null)
                    r.MaxChildrens = childs.Descendants("i").Where(d => d.Attributes["class"].Value.Contains("bicon-occupancychild")).Count().ToString();

                hotel.Rooms.Add(r);
            }


            //Finding Alternative Hotels
            IEnumerable<HtmlNode> alternHotels = document.DocumentNode.SelectNodes("//*[contains(@id,'althotelsTable')]").Descendants("td");

            Hotel h;
            foreach (HtmlNode item in alternHotels)
            {
                h = new Hotel();

                //Hotel Name
                h.Name = item.Element("p").Element("a").InnerHtml;

                //Hotel Stars
                HtmlNode node = item.Element("p").Element("i").Descendants("svg").Where(d => d.Attributes.Contains("class")).FirstOrDefault();
                if (node != null)
                {
                    string rating = node.Attributes.Where(d => d.Value.Contains("-sprite-ratings_")).FirstOrDefault().Value.ToString();
                    h.Stars = rating.Split('_')[2];
                }
                
                //Hotel Description
                h.Description = item.Element("span").InnerHtml.Replace("\n","");

                //Hotel Total Reviews
                string totReviews = item.Element("div").SelectNodes("//*[contains(@class,'review-score-widget__subtext')]").FirstOrDefault().InnerHtml;
                h.TotalReviews = totReviews.Replace(" ", "|").Split('|')[0].Replace("\n", "");

                //Hotel Score Review
                string scoreReview = item.Element("div").SelectNodes("//*[contains(@class,'review-score-badge')]").FirstOrDefault().InnerHtml;
                h.ReviewPoints = scoreReview.Replace("<span class=\"review-score__decimal-separator\">", "").Replace("</span>", "").Replace("\n", "");

                hotel.AlternativeHotels.Add(h);
            }

            ViewData["JSON"] = JsonConvert.SerializeObject(hotel).ToString();

            return View("Index");
        }



    }
}