using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CST8259_Lab3.Models
{
    public class RestaurantOverviewViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Rataurant")]
        public string Name { get; set; }
        [Display(Name = "Food Type")]
        public string FoodType { get; set; }
        [Display(Name = "Rating (best=5)")]
        public decimal Rating { get; set; }
        [Display(Name = "Cost (most expensive=5)")]
        public decimal Cost { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Province")]
        public string ProvinceState { get; set; }

        public static List<RestaurantOverviewViewModel> GetRestaurantOverviews(restaurantReviews reviews)
        {
            List<RestaurantOverviewViewModel> overviews = new List<RestaurantOverviewViewModel>();
            int id = 0;
            foreach (restaurantReviewsRestaurant rs in reviews.restaurant)
            {
                RestaurantOverviewViewModel overview = new RestaurantOverviewViewModel();
                overview.Id = id++;
                overview.Name = rs.name;
                overview.FoodType = rs.reviews.rivew.food;
                decimal maxCost = rs.reviews.rivew.priceRange.maxExclusive == 0 ? 5 : rs.reviews.rivew.priceRange.maxExclusive;
                overview.Cost = rs.reviews.rivew.priceRange.Value / maxCost * 5;

                decimal maxRating = rs.reviews.rivew.rating.maxExclusive == 0 ? 5 : rs.reviews.rivew.rating.maxExclusive;
                overview.Rating = rs.reviews.rivew.rating.Value / maxRating * 5;

                overview.City = rs.address.city;
                overview.ProvinceState = rs.address.state_province.ToString();

                overviews.Add(overview);
            }
            return overviews;
        }
    }

}
