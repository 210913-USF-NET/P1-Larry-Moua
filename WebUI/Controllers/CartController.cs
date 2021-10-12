using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using RBBL;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IBL _bl;
        public CartController(IBL bl)
        {
            _bl = bl;
        }
        // GET: CartController
        public ActionResult Index()
        {
            var userCheck = HttpContext.Request.Cookies["user"];
            if (userCheck == "true")
            {
                ViewData["status"] = "user";
            }
            return View(DisplayCart.cart);
        }

        public ActionResult Checkout()
        {
            if (DisplayCart.cart.Count == 0)
            {
                HttpContext.Response.Cookies.Append("checkoutMsg", "Cart is empty.");
                return RedirectToAction(nameof(Index));
            }   else
            {
                int userId = Int32.Parse(HttpContext.Request.Cookies["userId"]);
                for (int i = 0; i < DisplayCart.cart.Count; i++)
                {
                    Order newOrd = new Order();
                    _bl.AddOrder(newOrd, userId, DisplayCart.cart[i].ReturnWarehouseId(), DisplayCart.cart[i].ReturnPhotoId());
                }
                DisplayCart.cart.Clear();
                HttpContext.Response.Cookies.Append("checkoutMsg", "Checkout Successful.");
                return RedirectToAction(nameof(Index));
            } 

        }
    }
}
