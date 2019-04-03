using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerityFinancial.Models;

namespace Johns_WebPage.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var model = new CustomerListItems[0];
            return View(model);
        }
    }
}