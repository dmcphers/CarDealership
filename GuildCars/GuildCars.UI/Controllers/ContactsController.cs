using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult AddContact()
        {
            var contact = new Contact();
            return View(contact);
        }

        [AllowAnonymous]
        [HttpPost]

        public ActionResult AddContact(Contact contact)
        {
            var repo = ContactsRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                repo.AddContact(contact);
                return RedirectToAction("Index", "Home");
            }
            return View(contact);

        }
    }
}