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
    public class BondsController : Controller
    {
        // GET: Bonds
        public ActionResult Index()
        {
            var CustomerId = Guid.Parse(User.Identity.GetUserId());
            var service = new BondServices(CustomerId);
            var model = service.GetBondList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BondCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var BondId = Guid.Parse(User.Identity.GetUserId());
            var service = new BondServices(BondId);

            service.CreateBond(model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBondService();
            var model = svc.GetBondById(id);
            return View(model);
        }

        public BondServices CreateBondService()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            var svc = new BondServices(id);
            return svc;
        }
        public ActionResult BTrade(int id)
        {
            var service = CreateBondService();
            var detail = service.GetBondById(id);
            var model =
                new BondTrade
                {
                    BondId = detail.BondID,
                    BondName = detail.BondName,
                    BondAbbev = detail.BondAbbev,
                    Cost = detail.Cost,
                    CostCurrent = detail.CostCurrent,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BTrade(int id, BondTrade model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateBondService();
            if (service.UpdateBond(model))
            {
                TempData["SaveResult"] = "Thank you for Trading with us today.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Bond could not be traded at this time.");
            return View(model);
        }
    }
}