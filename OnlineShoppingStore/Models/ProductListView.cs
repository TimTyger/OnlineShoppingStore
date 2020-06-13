using OnlineShoppingStore.DB;
using OnlineShoppingStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class ProductListView : IProductListView
    {
        public List<Product> ProductCollection { get; set; }

        public string Message { get; set; }
    }
}