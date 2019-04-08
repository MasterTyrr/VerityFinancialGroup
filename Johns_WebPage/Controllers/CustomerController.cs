using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerityFinancial.Models;
using VerityFinancial.Services;

namespace Johns_WebPage.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var CustomerId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerServices(CustomerId);
            var model = service.GetCustomerList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var CustomerId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerServices(CustomerId);

            service.CreateCustomer(model);

            return RedirectToAction("Index");
        }
    }
}