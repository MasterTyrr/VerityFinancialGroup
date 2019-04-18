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
            var service = new PortfolioService(_id);
            var model = service.GetPortfolio();
            //ViewBag.Portfolio = new SelectList(model, "PortfolioID", "StockAbbev");
            //ViewBag.Portfolio = new SelectList(model, "PortfolioID", "Scost");
            //ViewBag.Portfolio = new SelectList(model, "PortfolioID", "BondAbbev");
            //ViewBag.Portfolio = new SelectList(model, "PortfolioID", "Bcost");
            return View(model);
        }

        public ActionResult Create()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            var Service = new CustomerServices(id);
            var custList = Service.GetCustomerList();

            ViewBag.CustomerID = new SelectList(custList, "CustomerId", "LastName");

            var stockService = new StockServices(id);
            var stockList = stockService.GetStockList();

            ViewBag.StockID = new SelectList(stockList, "StockID", "StockAbbev");

            var bondService = new BondServices(id);
            var bondList = bondService.GetBondList();

            ViewBag.BondID = new SelectList(bondList, "BondID", "BondAbbev");

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
                return RedirectToAction("Index", "Portfolio");
            }

           
            //var portList = service.GetPortfolio();

            //ViewBag.ClientPortfolioId = new SelectList(portList, "ClientPortfolioID", "CustomerName");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = GetPortfolioService();
            var model = service.GetPortfolioById(id);
            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var service = GetPortfolioService();
            var detail = service.GetPortfolioById(id);
            var model = new ClientPortfolioTrade
            {
                PortfolioID = detail.PortfolioID
            };

            var _id = Guid.Parse(User.Identity.GetUserId());
            var Service = new CustomerServices(_id);
            var custList = Service.GetCustomerList();

            ViewBag.CustomerID = new SelectList(custList, "CustomerId", "LastName");

            var stockService = new StockServices(_id);
            var stockList = stockService.GetStockList();

            ViewBag.StockID = new SelectList(stockList, "StockID", "StockAbbev");

            var bondService = new BondServices(_id);
            var bondList = bondService.GetBondList();

            ViewBag.BondID = new SelectList(bondList, "BondID", "BondAbbev");
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ClientPortfolioTrade model)
        {
            var _id = Guid.Parse(User.Identity.GetUserId());
            var portService = new PortfolioService(_id);
            var portList = portService.GetPortfolio();

            ViewBag.ClientPortfolioID = new SelectList(portList, "ClientPortfolioID", "CustomerName");

            if (!ModelState.IsValid) return View(model);

            var service = GetPortfolioService();

            if (service.EditPortfolio(model))
                return RedirectToAction("Index", "Portfolio");
            ModelState.AddModelError("", "Could not update the Portfolio");
            return View(model);
        }

        // GET: ThemeParkRating/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = GetPortfolioService();
            var model = service.GetPortfolioById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteRating(int id)
        {
            var service = GetPortfolioService();

            if (service.DeletePortfolio(id))
                return RedirectToAction("Index", "Portfolio");

            ModelState.AddModelError("", "Could not delete Rating");

            return RedirectToAction("Delete", new { id });
        }

        private PortfolioService GetPortfolioService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PortfolioService(userId);
            return service;
        }
    }
}