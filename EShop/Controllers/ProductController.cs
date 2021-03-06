using EShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(); 
        }
        public ActionResult GetProducts(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 9;
            var items = context.Products.OrderByDescending(m => m.Product_ID).ToPagedList(pageNumber , pageSize);
            return PartialView("_Products", items);
        }
        public ActionResult GetSomeProducts(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 6;
            var items = context.Products.OrderByDescending(m => m.Product_ID).ToPagedList(pageNumber, pageSize);
            return PartialView("_Products", items);
        }
        public ActionResult ProductDetails(int id)
        {
            var product = context.Products.FirstOrDefault(m => m.Product_ID == id);
            return View(product);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AddProducts()
        {
            List<string> sizes = new List<string>() { "X-Large", "Large", "Mideum", "Small" };
            var categories = context.Categories.ToList();
            var Manufacturer = context.Manufactures.ToList();
            ViewBag.Sizes = sizes;
            ViewBag.Categories = categories;
            ViewBag.Manufacturers = Manufacturer;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducts(Product product)
        {
            if (ModelState.IsValid == true)
            {
                Product newproduct = new Product()
                {
                    Product_Name = product.Product_Name,
                    Product_Price = product.Product_Price,
                    Product_Size = product.Product_Size,
                    Product_Color = product.Product_Color,
                    Product_Image = product.Product_Image,
                    Product_Short_Description = product.Product_Short_Description,
                    Product_Long_Description = product.Product_Long_Description,
                    Manufacture_ID = product.Manufacture_ID,
                    Category_ID = product.Category_ID,
                    Publication_Status = 1
                };
                context.Products.Add(newproduct);
                context.SaveChanges();
                return View("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Somthing Wrong , Try Again..");
                List<string> sizes = new List<string>() { "X-Large", "Large", "Mideum", "Small" };
                var categories = context.Categories.ToList();
                var Manufacturer = context.Manufactures.ToList();
                ViewBag.Sizes = sizes;
                ViewBag.Categories = categories;
                ViewBag.Manufacturers = Manufacturer;
                return View(product);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ProductInformation()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditeInProduct(int id)
        {
            var product = context.Products.FirstOrDefault(m => m.Product_ID == id);
            List<string> sizes = new List<string>() { "X-Large", "Large", "Mideum", "Small" };
            var categories = context.Categories.ToList();
            var Manufacturer = context.Manufactures.ToList();
            ViewBag.Sizes = sizes;
            ViewBag.Categories = categories;
            ViewBag.Manufacturers = Manufacturer;
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditeInProduct(int id , Product product)
        {
            if (ModelState.IsValid == true)
            {
                var EditedProduct = context.Products.FirstOrDefault(m => m.Product_ID == id);
                EditedProduct.Product_Name = product.Product_Name;
                EditedProduct.Product_Price = product.Product_Price;
                EditedProduct.Product_Size = product.Product_Size;
                EditedProduct.Product_Color = product.Product_Color;
                EditedProduct.Product_Image = product.Product_Image;
                EditedProduct.Product_Short_Description = product.Product_Short_Description;
                EditedProduct.Product_Long_Description = product.Product_Long_Description;
                EditedProduct.Manufacture_ID = product.Manufacture_ID;
                EditedProduct.Category_ID = product.Category_ID;
                EditedProduct.Publication_Status = 1;
                context.SaveChanges();
                return RedirectToAction("ProductInformation");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Somthing Wrong , Try Again..");
                List<string> sizes = new List<string>() { "X-Large", "Large", "Mideum", "Small" };
                var categories = context.Categories.ToList();
                var Manufacturer = context.Manufactures.ToList();
                ViewBag.Sizes = sizes;
                ViewBag.Categories = categories;
                ViewBag.Manufacturers = Manufacturer;
                return View(product);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteFromProduct(int id)
        {
            try
            {
                var product = context.Products.FirstOrDefault(m => m.Product_ID == id);
                context.Products.Remove(product);
                context.SaveChanges();
                return RedirectToAction("ProductInformation");
            }
            catch(Exception e)
            {
                return RedirectToAction("ProductInformation");
            }
        }
    }
}