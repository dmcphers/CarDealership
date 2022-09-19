using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class SalesController : Controller
    {
        [Authorize(Roles = "Admin, Sales")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Sales")]

        public ActionResult Purchase(int id)
        {
            var vehiclesRepo = VehiclesRepositoryFactory.GetRepository();
            var statesRepo = StatesRepositoryFactory.GetRepository();
            var purchaseTypesRepo = PurchaseTypesRepositoryFactory.GetRepository();

            var model = new PurchaseViewModel();

            model.vehicle = vehiclesRepo.GetDetails(id);

            model.purchase = new PurchaseAddViewModel();
            model.purchase.States = new SelectList(statesRepo.GetAll(), "StateID", "StateID");
            model.purchase.PurchaseTypes = new SelectList(purchaseTypesRepo.GetAll(), "PurchaseTypeID", "PurchaseTypeName");

            model.purchase.Purchase = new Purchase();

            model.purchase.Purchase.VehicleID = model.vehicle.VehicleID;
            Session["VIN"] = model.vehicle.VINNumber;

            return View(model);
        }

        [Authorize(Roles = "Admin, Sales")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {

            var vehiclesRepo = VehiclesRepositoryFactory.GetRepository();
            var statesRepo = StatesRepositoryFactory.GetRepository();
            var purchaseTypesRepo = PurchaseTypesRepositoryFactory.GetRepository();
            var purchasesRepo = PurchasesRepositoryFactory.GetRepository();


            if (ModelState.IsValid)
            {
                model.purchase.Purchase.UserID = AuthorizeUtilities.GetUserId(this);

                try
                {
                    {
                        purchasesRepo.AddPurchase(model.purchase.Purchase);
                        TempData["notice"] = "Purchase successfully added";

                        return RedirectToAction("Index", "Sales");

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            model.vehicle = vehiclesRepo.GetDetails(model.purchase.Purchase.VehicleID);
            model.purchase.States = new SelectList(statesRepo.GetAll(), "StateID", "StateID");
            model.purchase.PurchaseTypes = new SelectList(purchaseTypesRepo.GetAll(), "PurchaseTypeID", "PurchaseTypeName");
            return View(model);

        }
    }
}