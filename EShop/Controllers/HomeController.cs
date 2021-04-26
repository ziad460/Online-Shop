using EShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryTab()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            ViewBag.WinterCollection = context.Products
                                       .Where(m => m.Product_Short_Description.Contains("Winter"))
                                       .Take(4).ToList();
            ViewBag.TShirts = context.Products
                                       .Where(m => m.Product_Short_Description.Contains("Shirt"))
                                       .Take(4).ToList();
            ViewBag.SunGlasses = context.Products
                                       .Where(m => m.Product_Short_Description.Contains("Glasses"))
                                       .Take(4).ToList();
            ViewBag.IslamicOutfit = context.Products
                                       .Where(m => m.Product_Short_Description.Contains("Outfit"))
                                       .Take(4).ToList();
            ViewBag.MiniDress = context.Products
                                       .Where(m => m.Product_Short_Description.Contains("Mini Dress"))
                                       .Take(4).ToList();
            return PartialView("_CategoryTab");
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult ErrorPageNotFound()
        {
            return View();
        }
        
    }
}