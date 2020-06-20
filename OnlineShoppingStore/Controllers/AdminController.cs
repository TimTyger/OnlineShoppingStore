using OnlineShoppingStore.DB;
using OnlineShoppingStore.Interfaces;
using OnlineShoppingStore.Models;
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

        public ActionResult Categories(string message)

        {

            List<Category> categoryList = unitOfWork.GetRepositoryInstance<Category>().GetAllRecords().Where(i => i.IsActive == true).ToList();
            var List = new CategoryListView()
            {
                CategoryCollection = categoryList,
                Message = message
            };
            return View(List);
        }

        public ActionResult AddCategory()
        {
            var model = new CategoryView();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryView categoryView)
        {
            if (categoryView == null)
            {
                throw new ArgumentNullException(nameof(categoryView));
            }
            List<Category> categoryList = unitOfWork.GetRepositoryInstance<Category>().GetAllRecords().Where(i => i.IsActive == true).ToList();
            foreach (var item in categoryList)
            {
                if (item.IsActive == false && categoryView.CategoryName == item.CategoryName)
                {
                    var model = new Category {IsActive = true };
                    unitOfWork.GetRepositoryInstance<Category>().Update(model);
                    var prompt = string.Format("Category Added Successfully");
                    return RedirectToAction("Categories", new { message = prompt });
                }
                if (item.IsActive == true && categoryView.CategoryName == item.CategoryName)
                {
                    var prompt = string.Format("Category already exists");
                    return RedirectToAction("Categories", new {message= prompt });
                }
            }
            var category = new Category { IsActive = true, CategoryName = categoryView.CategoryName };
            unitOfWork.GetRepositoryInstance<Category>().Add(category);
            var message = string.Format("Category Created Successfully");
            return RedirectToAction("Categories", new { message });
        }

        public ActionResult EditCategory(int categoryId)
        {
            var categoryModel = unitOfWork.GetRepositoryInstance<Category>().GetFirstorDefault(categoryId);
            var categoryView = new CategoryView { CategoryId = categoryModel.CategoryId, CategoryName = categoryModel.CategoryName};
            return View("EditCategory", categoryView);
        }
        [HttpPost]
        public ActionResult EditCategory(CategoryView categoryModel)
        {
            if (categoryModel == null)
            {
                throw new ArgumentNullException(nameof(categoryModel));
            }
            var category = new Category { CategoryId = categoryModel.CategoryId, CategoryName = categoryModel.CategoryName, IsActive = true };
            unitOfWork.GetRepositoryInstance<Category>().Update(category);
            var message = string.Format("{0} succeessfully added", categoryModel.CategoryName);
            return RedirectToAction("Categories", new { message });
        }

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            var categoryList = unitOfWork.GetRepositoryInstance<Category>().GetAllRecords().Where(i => i.IsActive == true).ToList();
            foreach (var item in categoryList)
            {
                categories.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return categories;
        }
        public ActionResult Products(string message)
        {

            List<Product> productList = unitOfWork.GetRepositoryInstance<Product>().GetAllRecords().Where(i => i.IsActive == true).ToList();
            var List = new ProductListView()
            {
                ProductCollection = productList,
                Message = message
            };
            return View(List);
        }

        public ActionResult AddProduct()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel productModel)
        {
            if (productModel == null)
            {
                throw new ArgumentNullException(nameof(productModel));
            }
            List<Product> productList = unitOfWork.GetRepositoryInstance<Product>().GetAllRecords().Where(i => i.IsActive == true).ToList();
            foreach (var item in productList)
            {
                if (item.IsActive == false && productModel.ProductName == item.ProductName && productModel.Description ==item.Description )
                {
                    var model = new Product { IsActive = true,DateCreated=item.DateCreated, DateModified=DateTime.Now,Quantity=productModel.Quantity,IsFeatured = productModel.IsFeatured,Price= productModel.Price};
                    unitOfWork.GetRepositoryInstance<Product>().Update(model);
                    var prompt = string.Format("Product Modified Successfully");
                    return RedirectToAction("Products", new { message = prompt });
                }
                if (item.IsActive == true && productModel.ProductName == item.ProductName&& productModel.Description == item.Description)
                {
                    var prompt = string.Format("Product already exists");
                    return RedirectToAction("Categories", new { message = prompt });
                }
            }
            var product = new Product { IsActive = true, ProductName = productModel.ProductName,DateCreated = DateTime.Now, Quantity = productModel.Quantity, IsFeatured = productModel.IsFeatured, Price = productModel.Price};
            unitOfWork.GetRepositoryInstance<Product>().Add(product);
            var message = string.Format("Product Created Successfully");
            return RedirectToAction("Products", new { message });
        }

    }
}