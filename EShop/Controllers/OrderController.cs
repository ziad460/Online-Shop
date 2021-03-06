using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [Route("UserCart/{id}")]
        public ActionResult CreateOrder(int id, string username)
        {
            var user = context.Users.FirstOrDefault(m => m.UserName == username);
            var product = context.Products.FirstOrDefault(m => m.Product_ID == id);
            List<Order> orders = context.Orders.ToList();
            bool found = false;
            foreach (var item in orders)
            {
                if (item.Customer_ID == user.Id)
                {
                    found = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (found == false)
            {
                Order order = new Order()
                {
                    Customer_ID = user.Id,
                    Payment_ID = 1,
                    Order_Total = product.Product_Price,
                    Order_Status = 1,
                    Shipping = new Shipping()
                    {
                        Shipping_Email = user.Email,
                        Shipping_Name = user.UserName,
                        Shipping_Address = new ShippingAddress
                        {
                            Country = "Egypt",
                            City = "",
                            Street = "",
                        }
                    }
                };
                context.Orders.Add(order);
                OrderDetails orderdetails = new OrderDetails()
                {
                    Order_ID = order.Order_ID,
                    Product_ID = product.Product_ID,
                    Product_Name = product.Product_Name,
                    Product_Price = product.Product_Price,
                    Product_Sales_Quantity = 1,
                    Total_price = product.Product_Price * 1 
                };
                context.OrderDetails.Add(orderdetails);
                context.SaveChanges();
                return RedirectToAction("Cart", new { id = order.Order_ID });
            }
            else
            {
                var order = context.Orders.FirstOrDefault(m => m.Customer_ID == user.Id);
                OrderDetails orderdetails = new OrderDetails()
                {
                    Order_ID = order.Order_ID,
                    Product_ID = product.Product_ID,
                    Product_Name = product.Product_Name,
                    Product_Price = product.Product_Price,
                    Product_Sales_Quantity = 1,
                    Total_price = product.Product_Price * 1
                };
                context.OrderDetails.Add(orderdetails);
                context.SaveChanges();
                return RedirectToAction("Cart", new { id = order.Order_ID });
            }
        }
        public ActionResult Cart(int id)
        {
            double sum = 0;
            var order = context.Orders.FirstOrDefault(m => m.Order_ID == id);
            foreach (var item in order.OrderDetails)
            {
                sum = sum + item.Total_price;
            }
            ViewBag.SubTotal = sum;
            ViewBag.Total = ViewBag.SubTotal + 2.0;
            return View(order);
        }
        [Route("UserCart")]
        public ActionResult UserCart()
        {
            var user = context.Users.FirstOrDefault(m => m.UserName == User.Identity.Name);
            var order = context.Orders.FirstOrDefault(m => m.Customer_ID == user.Id);
            if (order != null)
            {
                return RedirectToAction("Cart", new { id = order.Order_ID });
            }
            else
            {
                double sum = 0;
                ViewBag.SubTotal = sum;
                ViewBag.Total = ViewBag.SubTotal + 2.0;
                Order neworder = new Order()
                {
                    Customer_ID = user.Id,
                    Payment_ID = 1,
                    Order_Total = 0,
                    Order_Status = 1,
                    Shipping = new Shipping()
                    {
                        Shipping_Email = user.Email,
                        Shipping_Name = user.UserName,
                        Shipping_Address = new ShippingAddress
                        {
                            Country = "Egypt",
                            City = "",
                            Street = "",
                        }
                    }
                };
                context.Orders.Add(neworder);
                context.SaveChanges();
                return RedirectToAction("Cart", new { id = neworder.Order_ID });
            }
        }

        [Route("DeleteProduct/{id}/{orderid}")]
        public ActionResult DeleteItem(int id, int orderid)
        {
            var product = context.OrderDetails.Where(m => m.Order_ID == orderid).FirstOrDefault(m => m.Product_ID == id);
            context.OrderDetails.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Cart", new { id = orderid });
        }

        public ActionResult Update(int quantity , int productid , int orderid)
        {
            var product = context.OrderDetails.Where(m => m.Order_ID == orderid)
                .FirstOrDefault(m => m.Product_ID == productid);
            product.Product_Sales_Quantity = quantity;
            product.Total_price = product.Product_Price * quantity;
            context.SaveChanges();
            return RedirectToAction("Cart", new { id = orderid });
        }

        [Route("CheckOutOrder/{id}")]
        public ActionResult CheckOut(int id)
        {
            double sum = 0;
            var order = context.Orders.FirstOrDefault(m => m.Order_ID == id);
            foreach (var item in order.OrderDetails)
            {
                sum += item.Total_price;
            }
            ViewBag.SubTotal = sum;
            ViewBag.Total = ViewBag.SubTotal + 2.0;
            return View(order); 
        }
        [Route("OrderDone")]
        public ActionResult OrderDone()
        {
            return Content("Order Is Submitted , Pleaz wait from 1:2 weeks to recieve it.");
        }
    }
}   