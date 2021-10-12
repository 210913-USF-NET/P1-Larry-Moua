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
    public class InventoryController : Controller
    {
        private IBL _bl;
        public InventoryController(IBL bl)
        {
            _bl = bl;
        }
        // GET: InventoryController
        public ActionResult Browse()
        {
            var userCheck = HttpContext.Request.Cookies["user"];
            if (userCheck == "true")
            {
                ViewData["status"] = "user";
            }
            List<Product> tempCatalog = new List<Product>();
            List<Photocard> allPhoto = _bl.GetAllPhotocard();
            List<Inventory> allInvent = _bl.GetAllInventory();
            var wareCheck = HttpContext.Request.Cookies["warehouse"];
            int wareId = 0;
            string setName = "";
            decimal setPrice = 0;
            if (wareCheck == "US")
            {
                wareId = 1;
            } else if (wareCheck == "DE")
            {
                wareId = 2;
            } else if (wareCheck == "KR")
            {
                wareId = 3;
            }

            foreach (Inventory invent in allInvent)
            {
                if (wareId == invent.WarehouseId && invent.Stock !=0)
                {
                    foreach (Photocard photo in allPhoto)
                    {
                        if (invent.PhotocardId == photo.Id)
                        {
                            setName = photo.SetId;
                            setPrice = photo.Price;
                        }
                    }
                    tempCatalog.Add(new Product(invent.Id, wareId, invent.PhotocardId, setName, setPrice, invent.Stock));
                }
            }
            return View(tempCatalog);
        }

        public ActionResult Add(int inventoryId)
        {
            HttpContext.Response.Cookies.Append("currentItem", inventoryId.ToString());
            return View(_bl.GetOneInventoryById(inventoryId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int inventoryId, Inventory inventory)
        {
            try
            {
                int currentItemId = Int32.Parse(HttpContext.Request.Cookies["currentItem"]);
                var selectInventory = _bl.GetOneInventoryById(currentItemId);
                var selectPhotocard = _bl.GetOnePhotocardById(selectInventory.PhotocardId);
                _bl.StockInventory(selectInventory, 1);
                HttpContext.Response.Cookies.Append("currentItem", "");

                DisplayCart.cart.Add(new Product(currentItemId, selectInventory.WarehouseId, selectInventory.PhotocardId, selectPhotocard.SetId, selectPhotocard.Price, 0));

                //HttpContext.Session.SetString("CartSession", JsonConvert.SerializeObject(selectPhotocard));

                return RedirectToAction(nameof(Browse));
            }
            catch
            {
                return RedirectToAction(nameof(Browse));
            }
        }
        public ActionResult Index()
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            List<Inventory> allInventory = _bl.GetAllInventory();
            return View(allInventory);
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventory inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddInventory(inventory);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View(_bl.GetOneInventoryById(id));
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inventory inventory)
        {
            try
            {
                _bl.UpdateInventory(inventory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View(_bl.GetOneInventoryById(id));
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inventory inventory)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
