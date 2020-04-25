using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class ShippingModel
    {
        public int ShippingDetailsId { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        public string ZipCode { get; set; }
        public decimal AmountPaid { get; set; }

        [Required(ErrorMessage = "Payment type is required")]
        public string PaymentType { get; set; }
        public int OrderId { get; set; }

        [Required(ErrorMessage = "User is required")]
        public int UserId { get; set; }
    }
}