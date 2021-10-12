using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using RBBL;
using WebUI.Models;

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
            List<Customer> allCustomer = _bl.GetAllCustomers();
            List<Warehouse> allWarehouse = _bl.GetAllWarehouse();
            List<Photocard> allPhotocard = _bl.GetAllPhotocard();
            List<Order> tempOrd = new List<Order>();
            int userId;
            int.TryParse(HttpContext.Request.Cookies["userId"], out userId);
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
                var viewmodelResult = from p in tempOrd
                                      join k in allCustomer on p.CustomerId equals k.Id
                                      join w in allWarehouse on p.WarehouseId equals w.Id
                                      join photo in allPhotocard on p.PhotocardId equals photo.Id
                                      orderby k.Id
                                      select new OrderVM { Id = p.Id, CustomerEmail = k.Email, WarehouseName = w.Name, PhotocardName = photo.SetId, DateandTime = p.DateandTime};
                return View(viewmodelResult);
                //return View(tempOrd);
            }
            else
            {
                ViewData["status"] = "admin";
                var viewmodelResult = from p in allOrd
                                      join k in allCustomer on p.CustomerId equals k.Id
                                      join w in allWarehouse on p.WarehouseId equals w.Id
                                      join photo in allPhotocard on p.PhotocardId equals photo.Id
                                      orderby p.Id
                                      select new OrderVM { Id = p.Id, CustomerEmail = k.Email, WarehouseName = w.Name, PhotocardName = photo.SetId, DateandTime = p.DateandTime };
                return View(viewmodelResult);
            }

        }
    }
}
