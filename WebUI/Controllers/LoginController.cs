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
                List<Customer> allCustomer = _bl.GetAllCustomers();
                foreach (Customer customer in allCustomer) {
                    if (customer.Email == email)
                    {
                        return View(_bl.GetOneCustomerByEmail(email));
                    }
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
