using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using RBBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IBL _bl;
        public LoginController(IBL bl)
        {
            _bl = bl;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Success(string email)
        {
            try
            {
                bool success = false;
                List<Customer> allCustomer = _bl.GetAllCustomers();
                foreach (Customer customer in allCustomer) {
                    if (customer.Email == email)
                    {
                        HttpContext.Response.Cookies.Append("userEmail", email);
                        HttpContext.Response.Cookies.Append("user", "true");
                        HttpContext.Response.Cookies.Append("admin", "false");
                        HttpContext.Response.Cookies.Append("warehouse", "US");
                        success = true;
                        return View(_bl.GetOneCustomerByEmail(email));
                    }
                }

                if (email == "@dmin")
                {
                    HttpContext.Response.Cookies.Append("userEmail", email);
                    HttpContext.Response.Cookies.Append("user", "false");
                    HttpContext.Response.Cookies.Append("admin", "true");
                    HttpContext.Response.Cookies.Append("warehouse", "US");
                    success = true;
                    return Content("Welcome Admin.");
                }

                if (!success)
                {
                    return Content("Input does not match our records. Please try again.");
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}
