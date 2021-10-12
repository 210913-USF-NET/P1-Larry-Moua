using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using RBBL;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IBL _bl;
        public OrderController(IBL bl)
        {
            _bl = bl;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            List<Order> allOrd = _bl.GetAllOrders();
            List<Order> tempOrd = new List<Order>();
            int userId = Int32.Parse(HttpContext.Request.Cookies["userId"]);
            var userCheck = HttpContext.Request.Cookies["user"];
            if (userCheck == "true")
            {
                ViewData["status"] = "user";
                foreach (Order ord in allOrd)
                {
                    if (userId == ord.CustomerId)
                    {
                        tempOrd.Add(ord);
                    }
                }
                return View(tempOrd);
            }
            else
            {
                ViewData["status"] = "admin";
                return View(_bl.GetAllOrders());
            }

        }
    }
}
