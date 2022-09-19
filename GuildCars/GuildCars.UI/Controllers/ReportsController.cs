using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class ReportsController : Controller
    {

        ApplicationDbContext _context;

        public ReportsController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize(Roles = "Admin")]
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Sales()
        {
            List<ApplicationUser> modellist = _context.Users.ToList();

            var users = (from m in modellist
                         select new { m.Id, m.UserName }).ToList();

            ViewBag.Name = new SelectList(users, "UserName", "UserName");

            return View();
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Inventory()
        {

            return View();
        }
    }
}