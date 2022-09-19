using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ApplicationDbContext _context;
       

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        // GET: Admin
        public ActionResult Vehicles()
        {
            return View();
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult AddVehicle()
        {
            var model = new VehicleAddViewModel();

            var makesRepo = MakesRepositoryFactory.GetRepository();
            var modelsRepo = ModelsRepositoryFactory.GetRepository();
            var conditionTypesRepo = ConditionTypesRepositoryFactory.GetRepository();
            var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
            var exteriorColorsRepo = ExteriorColorsRepositoryFactory.GetRepository();
            var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();
            var transmissionsRepo = TransmissionsRepositoryFactory.GetRepository();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeID", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelID", "ModelName");
            model.ConditionTypes = new SelectList(conditionTypesRepo.GetAll(), "ConditionTypeID", "ConditionTypeName");
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleID", "BodyStyleName");
            model.ExteriorColors = new SelectList(exteriorColorsRepo.GetAll(), "ExteriorColorID", "ExteriorColorName");
            model.InteriorColors = new SelectList(interiorColorsRepo.GetAll(), "InteriorColorID", "InteriorColorName");
            model.Transmissions = new SelectList(transmissionsRepo.GetAll(), "TransmissionID", "TransmissionName");

            model.Vehicle = new Vehicle();

            return View(model);

        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        [HttpPost]
        public ActionResult AddVehicle(VehicleAddViewModel model)
        {

            if (ModelState.IsValid)
            {
                var repo = VehiclesRepositoryFactory.GetRepository();

                try
                {
                    var parameters = new InventorySearchParameters()
                    {
                        QuickSearch = null,
                        MaxPrice = null,
                        MinPrice = null,
                        MinYear = null,
                        MaxYear = null,
                        ConditionTypeName = null
                    };


                    var count = repo.SearchInventory(parameters).Max(m => m.VehicleID) + 1;

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = "inventory-" + count;

                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        model.ImageUpload.SaveAs(filePath);

                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);
                    }

                    repo.Insert(model.Vehicle);

                    return RedirectToAction("EditVehicle", new { id = model.Vehicle.VehicleID });

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            var makesRepo = MakesRepositoryFactory.GetRepository();
            var modelsRepo = ModelsRepositoryFactory.GetRepository();
            var conditionTypesRepo = ConditionTypesRepositoryFactory.GetRepository();
            var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
            var exteriorColorsRepo = ExteriorColorsRepositoryFactory.GetRepository();
            var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();
            var transmissionsRepo = TransmissionsRepositoryFactory.GetRepository();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeID", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelID", "ModelName");
            model.ConditionTypes = new SelectList(conditionTypesRepo.GetAll(), "ConditionTypeID", "ConditionTypeName");
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleID", "BodyStyleName");
            model.ExteriorColors = new SelectList(exteriorColorsRepo.GetAll(), "ExteriorColorID", "ExteriorColorName");
            model.InteriorColors = new SelectList(interiorColorsRepo.GetAll(), "InteriorColorID", "InteriorColorName");
            model.Transmissions = new SelectList(transmissionsRepo.GetAll(), "TransmissionID", "TransmissionName");


            return View(model);

        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Delete(int id)
        {
            var repo = VehiclesRepositoryFactory.GetRepository();

            var userid = AuthorizeUtilities.GetUserId(this);

            repo.Delete(id);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult EditVehicle(int id)
        {
            var model = new VehicleEditViewModel();

            var makesRepo = MakesRepositoryFactory.GetRepository();
            var modelsRepo = ModelsRepositoryFactory.GetRepository();
            var conditionTypesRepo = ConditionTypesRepositoryFactory.GetRepository();
            var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
            var exteriorColorsRepo = ExteriorColorsRepositoryFactory.GetRepository();
            var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();
            var transmissionsRepo = TransmissionsRepositoryFactory.GetRepository();
            var vehiclesRepo = VehiclesRepositoryFactory.GetRepository();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeID", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelID", "ModelName");
            model.ConditionTypes = new SelectList(conditionTypesRepo.GetAll(), "ConditionTypeID", "ConditionTypeName");
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleID", "BodyStyleName");
            model.ExteriorColors = new SelectList(exteriorColorsRepo.GetAll(), "ExteriorColorID", "ExteriorColorName");
            model.InteriorColors = new SelectList(interiorColorsRepo.GetAll(), "InteriorColorID", "InteriorColorName");
            model.Transmissions = new SelectList(transmissionsRepo.GetAll(), "TransmissionID", "TransmissionName");
            model.Vehicle = vehiclesRepo.GetById(id);

            return View(model);

        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        [HttpPost]
        public ActionResult EditVehicle(VehicleEditViewModel model, string buttonType)
        {
            if (buttonType == "Save")
            {

                if (ModelState.IsValid)
                {
                    var repo = VehiclesRepositoryFactory.GetRepository();

                    try
                    {
                        var oldVehicle = repo.GetById(model.Vehicle.VehicleID);

                        if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                        {
                            var savepath = Server.MapPath("~/Images");

                            string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                            string extension = Path.GetExtension(model.ImageUpload.FileName);

                            var filePath = Path.Combine(savepath, fileName + extension);

                            // delete old file
                            var oldPath = Path.Combine(savepath, oldVehicle.ImageFileName);
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }

                            model.ImageUpload.SaveAs(filePath);

                            model.Vehicle.ImageFileName = Path.GetFileName(filePath);

                        }
                        else
                        {
                            // user did not replace the old file so keep old file name
                            model.Vehicle.ImageFileName = oldVehicle.ImageFileName;
                        }

                        repo.Update(model.Vehicle);

                        return RedirectToAction("EditVehicle", new { id = model.Vehicle.VehicleID });

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }

                var makesRepo = MakesRepositoryFactory.GetRepository();
                var modelsRepo = ModelsRepositoryFactory.GetRepository();
                var conditionTypesRepo = ConditionTypesRepositoryFactory.GetRepository();
                var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
                var exteriorColorsRepo = ExteriorColorsRepositoryFactory.GetRepository();
                var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();
                var transmissionsRepo = TransmissionsRepositoryFactory.GetRepository();

                model.Makes = new SelectList(makesRepo.GetAll(), "MakeID", "MakeName");
                model.Models = new SelectList(modelsRepo.GetAll(), "ModelID", "ModelName");
                model.ConditionTypes = new SelectList(conditionTypesRepo.GetAll(), "ConditionTypeID", "ConditionTypeName");
                model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleID", "BodyStyleName");
                model.ExteriorColors = new SelectList(exteriorColorsRepo.GetAll(), "ExteriorColorID", "ExteriorColorName");
                model.InteriorColors = new SelectList(interiorColorsRepo.GetAll(), "InteriorColorID", "InteriorColorName");
                model.Transmissions = new SelectList(transmissionsRepo.GetAll(), "TransmissionID", "TransmissionName");
            }
            if (buttonType == "Delete")
            {
                var repo = VehiclesRepositoryFactory.GetRepository();

                var oldVehicle = repo.GetById(model.Vehicle.VehicleID);

                var savepath = Server.MapPath("~/Images");

                var oldPath = Path.Combine(savepath, oldVehicle.ImageFileName);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                return RedirectToAction("Delete", new { id = model.Vehicle.VehicleID });
            }

            return View(model);
        }

        
        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Makes()
        {
            var userid = AuthorizeUtilities.GetUserId(this);
            var email = AuthorizeUtilities.GetUserEmail(this);
            
            var model = new Make();

            model.UserID = userid;
            model.Email = email;
            



            return View(model);
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        [HttpPost]
        public ActionResult Makes(Make model)
        {
            var repo = MakesRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                repo.AddMake(model);
                return RedirectToAction("Makes", "Admin");
            }

            return View(model);
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Models()
        {
            var repo = MakesRepositoryFactory.GetRepository();

            var userid = AuthorizeUtilities.GetUserId(this);
            var email = AuthorizeUtilities.GetUserEmail(this);


            var model = new Model();
            model.UserID = userid;
            model.Email = email;


            ViewBag.Name = new SelectList(repo.GetAll(), "MakeID", "MakeName");

            return View(model);
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        [HttpPost]
        public ActionResult Models(Model model)
        {
            var repo1 = MakesRepositoryFactory.GetRepository();
            var make = repo1.GetByID(model.MakeID);

            model.MakeName = make.MakeName;

            var repo2 = ModelsRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                repo2.AddModel(model);
                return RedirectToAction("Models", "Admin");
            }

            var repo3 = MakesRepositoryFactory.GetRepository();

            ViewBag.Name = new SelectList(repo3.GetAll(), "MakeID", "MakeName");
            return View(model);
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Specials()
        {

            var model = new Special();

            return View(model);
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        [HttpPost]
        public ActionResult Specials(Special model)
        {
            var repo = SpecialsRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                repo.AddSpecial(model);
                return RedirectToAction("Specials", "Admin");
            }
            return View(model);
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Users()
        {
            List<UserViewModel> modellist = new List<UserViewModel>();
            var userManager = new UserManager<ApplicationUser, string>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            if (userManager.Users.ToList().Count != 0)
            {
                userManager.Users.ToList().ForEach(u =>
                {
                    UserViewModel model = new UserViewModel();
                    model.User = u;
                    model.Roles = getallRoles(u.Roles.FirstOrDefault().RoleId);
                    modellist.Add(model);
                });
            }
            return View(modellist);
        }


        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult AddUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            ViewBag.Name = new SelectList(context.Roles
                                .ToList(), "Name", "Name");

            return View();
        }


        
        [HttpPost]
        [Authorize]
        [CustomAuthorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(RegisterViewModel model)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, LastName = model.LastName, FirstName = model.FirstName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //Assign Role to user Here       
                    await UserManager.AddToRoleAsync(user.Id, model.UserRoles);

                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Name = new SelectList(context.Roles
                    .ToList(), "Name", "Name");
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            ViewBag.Name = new SelectList(context.Roles
            .ToList(), "Name", "Name");
            return View(model);
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public SelectList getallRoles(string selectedRoleId = "1")
        {
            ApplicationDbContext context = new ApplicationDbContext();

            return new SelectList(context.Roles.ToList(), "Id", "Name", selectedRoleId);
        }
        

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult EditUser(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            
            var userManager = new UserManager<ApplicationUser, string>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole, string>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var model = new EditUserViewModel();

            model.User = userManager.FindById(id);

            model.Role = roleManager.FindById(model.User.Roles.FirstOrDefault().RoleId).Name;


            ViewBag.Name = new SelectList(context.Roles
                                .ToList(), "Name", "Name");

            return View(model);
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(EditUserViewModel model)

        {

            if (ModelState.IsValid)
            {
                
                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var roleManager = new RoleManager<IdentityRole, string>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                
                var user = await UserManager.FindByIdAsync(model.User.Id);
                user.FirstName = model.User.FirstName;
                user.LastName = model.User.LastName;

                if (model.Password != null && (model.Password == model.ConfirmPassword))
                {

                    UserManager.RemovePassword(user.Id);

                    var newPasswordHash = UserManager.PasswordHasher.HashPassword(model.Password);
 
                    await store.SetPasswordHashAsync(UserManager.FindById(user.Id), newPasswordHash);

                }


                var oldrole = roleManager.FindById(user.Roles.FirstOrDefault().RoleId);

                UserManager.RemoveFromRole(user.Id, oldrole.Name);

                UserManager.AddToRole(user.Id, model.Role);

                var updateResult = await UserManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    
                    return RedirectToAction("Users", "Admin");
                }
                ViewBag.Name = new SelectList(_context.Roles
                .ToList(), "Name", "Name");
                AddErrors(updateResult);
            }
            //failed - do something else and return
            ViewBag.Name = new SelectList(_context.Roles
           .ToList(), "Name", "Name");
            return View(model);
        }


        public ActionResult Unauthorized()
        {
            return View();
        }



        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize]
        [CustomAuthorize(Roles = "Admin")]
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}