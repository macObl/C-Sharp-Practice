using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CST8259_Lab3.Models;
using System.IO;
using System.Xml.Serialization;

namespace CST8259_Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string xmlFilePath = Path.GetFullPath("Data/resturant_reviews.xml");

            restaurantReviews restaurantReviews = null;
            using(FileStream xs = new FileStream(xmlFilePath, FileMode.Open))
            {
                XmlSerializer serializor = new XmlSerializer(typeof(restaurantReviews));
                restaurantReviews = (restaurantReviews)serializor.Deserialize(xs);
            }
            List<RestaurantOverviewViewModel> overviews = RestaurantOverviewViewModel.GetRestaurantOverviews(restaurantReviews);
            return View(overviews);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }

            string xmlFilePath = Path.GetFullPath("Data/resturant_reviews.xml");

            restaurantReviews restaurantReviews = null;
            using (FileStream xs = new FileStream(xmlFilePath, FileMode.Open))
            {
                XmlSerializer serializor = new XmlSerializer(typeof(restaurantReviews));
                restaurantReviews = (restaurantReviews)serializor.Deserialize(xs);
            }
            if(id.Value < 0 || id.Value >= restaurantReviews.restaurant.Length)
            {
                return RedirectToAction("Error");
            }
            restaurantReviewsRestaurant restaurant = restaurantReviews.restaurant[id.Value];
            RestaurantEditViewModel rest = RestaurantEditViewModel.GetRestaurantEditViewModel(restaurant);

            return View(rest);
        }

        [HttpPost]
        
        public IActionResult Edit(RestaurantEditViewModel rsVM)
        {
            string xmlFilePath = Path.GetFullPath("Data/resturant_reviews.xml");
            try
            {
                restaurantReviews restaurantReviews = null;
                using (FileStream xs = new FileStream(xmlFilePath, FileMode.Open))
                {
                    XmlSerializer serializor = new XmlSerializer(typeof(restaurantReviews));
                    restaurantReviews = (restaurantReviews)serializor.Deserialize(xs);
                }
                restaurantReviewsRestaurant restaurant = restaurantReviews.restaurant[rsVM.Id];

                restaurant.name = rsVM.Name;
                restaurant.address.street = rsVM.StreetAddress;
                restaurant.address.city = rsVM.City;
                restaurant.address.state_province = rsVM.ProvinceState;
                restaurant.address.postalCode = rsVM.PostalZipCode;
                restaurant.reviews.rivew.summary = rsVM.Summary;
                restaurant.reviews.rivew.rating.Value = (byte)rsVM.Rating;

                using (FileStream xs = new FileStream(xmlFilePath, FileMode.Create))
                {
                    XmlSerializer serializor = new XmlSerializer(typeof(restaurantReviews));
                    serializor.Serialize(xs, restaurantReviews);
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
