using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
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

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
