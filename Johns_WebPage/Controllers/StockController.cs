﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerityFinancial.Models;
using VerityFinancial.Services;

namespace Johns_WebPage.Controllers
{
    public class StockController : Controller
    {
        //GET: Stock
        public ActionResult Index()
        {
            var CustomerId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockServices(CustomerId);
            var model = service.GetStockList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var StockId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockServices(StockId);

            service.CreateStock(model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateStockService();
            var model = svc.GetStockById(id);
            return View(model);

        }

        public StockServices CreateStockService()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            var svc = new StockServices(id);
            return svc;
        }

        public ActionResult STrade(int id)
        {
            var service = CreateStockService();
            var detail = service.GetStockById(id);
            var model =
                new StockTrade
                {
                    StockId = detail.StockID,
                    StockName = detail.StockName,
                    StockAbbev = detail.StockAbbev,
                    Cost = detail.Cost,
                    CostCurrent = detail.CostCurrent,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult STrade(int id, StockTrade model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateStockService();
            if (service.UpdateStock(model))
            {
                TempData["SaveResult"] = "Thank you for Trading with us today.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Stock could not be traded at this time.");
            return View(model);
        }
    }
}