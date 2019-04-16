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
    public class PortfolioController : Controller
    {
        //GET: Portfolio
        public ActionResult Index()
        {
            var _id = Guid.Parse(User.Identity.GetUserId());
            return View();
        }

        public ActionResult Create()
        {
            var _id = Guid.Parse(User.Identity.GetUserId());
            var Service = new PortfolioService(_id);
            var PortList = Service.GetPortfolio();

            ViewBag.PortfolioID = new SelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientPortfolioCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var _id = Guid.Parse(User.Identity.GetUserId());
            var service = new PortfolioService(_id);

            if (service.CreatePortfolio(model))
            {
                return RedirectToAction("Index", "ClientPortfolio");
            }

           
            var portList = service.GetPortfolio(id);

            ViewBag.ClientPortfolioId = new SelectList(portList, "ClientPortfolioID", "CustomerName");

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ClientPortfolioEdit model)
        {
            var portService = new PortfolioService();
            var portList = portService.GetPortfolio();

            ViewBag.ClientPortfolioID = new SelectList(portList, "ClientPortfolioID", "CustomerName", model.CustomerID);

            if (!ModelState.IsValid) return View(model);

            var service = ();

            if
        }
    }
}