using GuildCars.Data.Factories;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }

        // GET: Vehicle details
        public ActionResult Details(int id)
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
            }

            var repo = VehiclesRepositoryFactory.GetRepository();

            var model = repo.GetDetails(id);

            return View(model);
        }
    }
}