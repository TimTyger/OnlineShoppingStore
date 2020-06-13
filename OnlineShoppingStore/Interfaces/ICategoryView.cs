using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Interfaces
{
    public interface ICategoryView
    {
        int CategoryId { get; set; }

        string CategoryName { get; set; }
        bool IsActive { get; set; }
        bool IsInactive { get; set; }

        string Message { get; set; }
    }
}
