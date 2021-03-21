using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CST8259_Lab3.Models
{
    public class RestaurantEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Province")]
        public StateProvinceType ProvinceState { get; set; }
        [Required]
        [RegularExpression(@"[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}",
                        ErrorMessage = "Must be in the form of A1A 1A1")]
        [Display(Name = "Postal Code")]
        public string PostalZipCode { get; set; }
        [Required]
        [Display(Name = "Summary")]
        public string Summary { get; set; }
        [Required]
        [Range(1, 5)]
        [Display(Name = "Rating (1 to 5)")]
        public decimal Rating { get; set; }

        public static RestaurantEditViewModel GetRestaurantEditViewModel(restaurantReviewsRestaurant rs)
        {
            RestaurantEditViewModel rsVM = new RestaurantEditViewModel();

            rsVM.Name = rs.name;
            rsVM.StreetAddress = rs.address.street;
            rsVM.City = rs.address.city;
            rsVM.ProvinceState = rs.address.state_province;
            rsVM.PostalZipCode = rs.address.postalCode;
            rsVM.Summary = rs.reviews.rivew.summary;
            rsVM.Rating = rs.reviews.rivew.rating.Value;

            return rsVM;

        }
    }
}
