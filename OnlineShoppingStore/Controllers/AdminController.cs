using OnlineShoppingStore.DB;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class AdminController : Controller
    {
        public GenericUnitOfWork unitOfWork = new GenericUnitOfWork();

        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {

            List<Category> categoryList = unitOfWork.GetRepositoryInstance<Category>().GetAllRecords().Where(i => i.IsActive == true).ToList();
            return View(categoryList);
        }
    }
}