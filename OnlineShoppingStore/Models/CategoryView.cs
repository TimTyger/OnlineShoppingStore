using OnlineShoppingStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class CategoryView : ICategoryView
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsInactive { get; set; }

        public string Message { get; set; }
    }
}