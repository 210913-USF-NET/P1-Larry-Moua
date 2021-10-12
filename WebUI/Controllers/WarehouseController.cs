using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RBBL;
using Models;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class WarehouseController : Controller
    {
        private IBL _bl;
        public WarehouseController(IBL bl)
        {
            _bl = bl;
        }
        // GET: WarehouseController

        public ActionResult Change()
        {
            var userCheck = HttpContext.Request.Cookies["user"];
            if (userCheck == "true")
            {
                ViewData["status"] = "user";
            }

            List<Warehouse> allWarehouse = _bl.GetAllWarehouse();
            return View(allWarehouse);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeTo(string warehouse)
        {
            try
            {
                if (warehouse == "1")
                {
                    HttpContext.Response.Cookies.Append("warehouse", "US");
                }

                if (warehouse == "2")
                {
                    HttpContext.Response.Cookies.Append("warehouse", "DE");
                }

                if (warehouse == "3")
                {
                    HttpContext.Response.Cookies.Append("warehouse", "KR");
                }
                return RedirectToAction(nameof(Change));
            }
            catch
            {
                return RedirectToAction(nameof(Change));
            }
        }
        public ActionResult Index()
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            List<Warehouse> allWarehouse = _bl.GetAllWarehouse();
            return View(allWarehouse);
        }

        // GET: WarehouseController/Create
        public ActionResult Create()
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View();
        }

        // POST: WarehouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Warehouse warehouse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddWarehouse(warehouse);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: WarehouseController/Edit/5
        public ActionResult Edit(int id)
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View(_bl.GetOneWarehouseById(id));
        }

        // POST: WarehouseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Warehouse warehouse)
        {
            try
            {
                _bl.UpdateWarehouse(warehouse);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WarehouseController/Delete/5
        public ActionResult Delete(int id)
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View(_bl.GetOneWarehouseById(id));
        }

        // POST: WarehouseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _bl.RemoveWarehouse(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
