using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomePageViewModel();
            model.featured = VehiclesRepositoryFactory.GetRepository().GetFeatured();
            model.specials = SpecialsRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        public ActionResult Specials()
        {
            var model = SpecialsRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        public ActionResult Contact()
        {
            var contact = new Contact();
            return View(contact);
        }

        [AllowAnonymous]
        [HttpPost]

        public ActionResult Contact(Contact contact)
        {
            var repo = ContactsRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                if ((contact.EmailAddress == "" || contact.EmailAddress == null) && (contact.PhoneNumber == "" || contact.PhoneNumber == null))
                {
                    // add error message to modelstate
                    ModelState.AddModelError("EmailAddress", "Either the email address or phone or both must be entered");
                    return View(contact);
                }
                repo.AddContact(contact);
                return RedirectToAction("Index", "Home");
            }
            return View(contact);

        }

        public ActionResult Unauthorized()
        {
            return View();
        }

        public ActionResult WarningMessage()
        {
            return View();
        }
    }
}