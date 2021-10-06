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
    public class ArtistController : Controller
    {

        private IBL _bl;
        public ArtistController(IBL bl)
        {
            _bl = bl;
        }

        // GET: ArtistController
        public ActionResult Index()
        {
            List<Artist> allArtist = _bl.GetAllArtist();
            return View(allArtist);
        }

        // GET: ArtistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArtistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artist artist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddArtist(artist);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ArtistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
