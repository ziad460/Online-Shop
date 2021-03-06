using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class SliderController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Slider
        public ActionResult Index()
        {
            var counter = 1;
            var sliderimages = context.Sliders.ToList();
            var FirstSlider = context.Sliders.FirstOrDefault();
            ViewBag.FirstSlider = FirstSlider;
            ViewBag.Counter = counter;
            return PartialView("_Slider", sliderimages);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AddToSlider()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToSlider(Slider slider)
        {
            if (ModelState.IsValid == true)
            {
                Slider newslider = new Slider()
                {
                    Content_Name = slider.Content_Name,
                    Content_Describtion = slider.Content_Describtion,
                    Content_Image = slider.Content_Image,
                };
                context.Sliders.Add(newslider);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Something Wrong!");
                return View(slider);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SliderInformation()
        {
            var sliders = context.Sliders.ToList();
            return View(sliders);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditeInSlider(int id)
        {
            var slider = context.Sliders.FirstOrDefault(m => m.Slider_ID == id);
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditeInSlider(Slider slider , int id)
        {
            if (ModelState.IsValid == true)
            {
                var Eslider = context.Sliders.FirstOrDefault(m => m.Slider_ID == id);
                Eslider.Content_Name = slider.Content_Name;
                Eslider.Content_Describtion = slider.Content_Describtion;
                Eslider.Content_Image = slider.Content_Image;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(slider);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteFromSlider(int id)
        {
            try
            {
                var slider = context.Sliders.FirstOrDefault(m => m.Slider_ID == id);
                context.Sliders.Remove(slider);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("SliderInformation");
            }

        }
    }
}