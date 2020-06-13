using OnlineShoppingStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Interfaces
{
    public interface IProductListView
    {
        List<Product> ProductCollection { get; set; }

        string Message { get; set; }
    }
}
