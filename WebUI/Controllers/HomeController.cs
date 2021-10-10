using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models;
using RBBL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userCheck = HttpContext.Request.Cookies["user"];
            var adminCheck = HttpContext.Request.Cookies["admin"];
            if (userCheck == "true")
            {
                ViewData["status"] = "user";
            } else if (adminCheck == "true")
            {
                ViewData["status"] = "admin";
            }
            else
            {
                ViewData["status"] = "guest";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            HttpContext.Response.Cookies.Append("user", "false");
            HttpContext.Response.Cookies.Append("admin", "false");
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("~/Views/Customer/Create.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
