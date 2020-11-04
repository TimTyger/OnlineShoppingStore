using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineShoppingStore.Interfaces
{
    public interface IProductModel
    {
         int ProductId { get; set; }

         string ProductName { get; set; }

         string Description { get; set; }

         int Quantity { get; set; }

         decimal Price { get; set; }

         int CategoryId { get; set; }
         bool IsActive { get; set; }
         Nullable<bool> IsInactive { get; set; }
         System.DateTime DateCreated { get; set; }
         Nullable<System.DateTime> DateModified { get; set; }
         bool IsFeatured { get; set; }
         string Message { get; set; }
         SelectList Categories { get; set; }
    }
}
