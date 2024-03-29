﻿using Microsoft.AspNetCore.Http;
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
    public class PhotocardController : Controller
    {
        private IBL _bl;
        public PhotocardController(IBL bl)
        {
            _bl = bl;
        }
        // GET: PhotocardController
        public ActionResult Index()
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            List<Idol> allIdol = _bl.GetAllIdol();
            List<Artist> allArtist = _bl.GetAllArtist();
            List<Album> allAlbum = _bl.GetAllAlbum();
            List<Photocard> allPhotocard = _bl.GetAllPhotocard();
            var viewmodelResult = from p in allPhotocard
                                  join k in allIdol on p.StageNameId equals k.Id
                                  join art in allArtist on p.GroupNameId equals art.Id
                                  join alb in allAlbum on p.AlbumId equals alb.Id
                                  orderby k.Id
                                  select new PhotocardVM { Id = p.Id, StageName = k.StageName, GroupName = art.GroupName, AlbumName = alb.AlbumName, SetId = p.SetId, Price = p.Price };
            return View(viewmodelResult);

            /*List<Photocard> allPhotocard = _bl.GetAllPhotocard();
            return View(allPhotocard);*/


        }

        // GET: PhotocardController/Create
        public ActionResult Create()
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View();
        }

        // POST: PhotocardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Photocard photocard)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddPhotocard(photocard);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PhotocardController/Edit/5
        public ActionResult Edit(int id)
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View(_bl.GetOnePhotocardById(id));
        }

        // POST: PhotocardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Photocard photocard)
        {
            try
            {
                _bl.UpdatePhotocard(photocard);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: PhotocardController/Delete/5
        public ActionResult Delete(int id)
        {
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            return View(_bl.GetOnePhotocardById(id));
        }

        // POST: PhotocardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Photocard photocard)
        {
            try
            {
                _bl.RemovePhotocard(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
