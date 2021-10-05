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
    public class CustomerController : Controller
    {
        private IBL _bl;
        public CustomerController(IBL bl)
        {
            _bl = bl;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            List<Customer> allCustomer = _bl.GetAllCustomers();
            return View(allCustomer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddCustomer(customer);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_bl.GetOneCustomerById(id));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                _bl.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_bl.GetOneCustomerById(id));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                _bl.RemoveCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
