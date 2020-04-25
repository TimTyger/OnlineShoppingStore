using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CartStatusId { get; set; }
    }

    public class CartStatusModel
    {
        public int CartStatusId { get; set; }

        [Required(ErrorMessage = "CartStatus is required")]
        public string CartStatus { get; set; }
    }

}