using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class VehiclesController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public ActionResult Add()
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(VehicleAddViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var repo = VehiclesRepositoryFactory.GetRepository();

                try
                {
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);

                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);
                    }

                    repo.Insert(model.Vehicle);

                    return RedirectToAction("Edit", new { id = model.Vehicle.VehicleID });

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


        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(VehicleEditViewModel model)
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

                        int counter = 1;

                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);

                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);

                        // delete old file
                        var oldPath = Path.Combine(savepath, oldVehicle.ImageFileName);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        // user did not replace the old file so keep old file name
                        model.Vehicle.ImageFileName = oldVehicle.ImageFileName;
                    }

                    repo.Update(model.Vehicle);

                    return RedirectToAction("Edit", new { id = model.Vehicle.VehicleID });

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
    }
}