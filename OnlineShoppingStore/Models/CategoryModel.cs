using OnlineShoppingStore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Models
{
    public class CategoryModel :ICategoryView
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="CategoryName is required")]
        [StringLength(50,ErrorMessage ="minimum length is 3 and maximum is 50", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsInactive { get; set; }
        public string Message { get; set; }

    }

    public class ProductModel: IProductModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        [StringLength(50, ErrorMessage = "minimum length is 2 and maximum is 50", MinimumLength = 2)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required]
        [Range(typeof(int), "1", "500", ErrorMessage ="Invalid quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(typeof(decimal), "1", "999999.99", ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }

        [Required]
        public byte[] ProductImage { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<bool> IsInactive { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public bool IsFeatured { get; set; }
        public string Message { get; set; }
        public SelectList Categories { get; set; }
    }

}