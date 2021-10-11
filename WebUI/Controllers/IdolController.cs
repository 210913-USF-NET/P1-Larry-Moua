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

    public class IdolController : Controller
    {
        private IBL _bl;
        public IdolController(IBL bl)
        {
            _bl = bl;
        }

        // GET: IdolController
        public ActionResult Index()
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }

            List<Idol> allIdol = _bl.GetAllIdol();
            return View(allIdol);
        }

        // GET: IdolController/Create
        public ActionResult Create()
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View();
        }

        // POST: IdolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Idol idol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddIdol(idol);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: IdolController/Edit/5
        public ActionResult Edit(int id)
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View(_bl.GetOneIdolById(id));
        }

        // POST: IdolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Idol idol)
        {
            try
            {
                _bl.UpdateIdol(idol);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IdolController/Delete/5
        public ActionResult Delete(int id)
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View(_bl.GetOneIdolById(id));
        }

        // POST: IdolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Idol idol)
        {
            try
            {
                _bl.RemoveIdol(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
