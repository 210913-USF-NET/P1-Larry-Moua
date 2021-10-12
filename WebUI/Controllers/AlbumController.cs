using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RBBL;
using Models;
using WebUI.Models;
using System.Dynamic;

namespace WebUI.Controllers
{
    public class AlbumController : Controller
    {
        private IBL _bl;
        public AlbumController(IBL bl)
        {
            _bl = bl;
        }
        // GET: AlbumController
        public ActionResult Index()
        {
            ViewData["status"] = "admin";
            List<Artist> allArtist = _bl.GetAllArtist();
            List<Album> allAlbum = _bl.GetAllAlbum();
            var viewmodelResult = from p in allArtist
                                  join k in allAlbum on p.Id equals k.ArtistId
                                  orderby k.Id
                                  select new AlbumVM { Id = k.Id, AlbumName = k.AlbumName, ArtistName = p.GroupName };
            return View(viewmodelResult);
        }


        // GET: AlbumController/Create
        public ActionResult Create()
        {
            ViewData["status"] = "admin";
            return View();
        }

        // POST: AlbumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddAlbum(album);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["status"] = "admin";
            return View(_bl.GetOneAlbumById(id));
        }

        // POST: AlbumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Album album)
        {
            try
            {
                _bl.UpdateAlbum(album);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: AlbumController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData["status"] = "admin";
            return View(_bl.GetOneAlbumById(id));
        }

        // POST: AlbumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Album album)
        {
            try
            {
                _bl.RemoveAlbum(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
