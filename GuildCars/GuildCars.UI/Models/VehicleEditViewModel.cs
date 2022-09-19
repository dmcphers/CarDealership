using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class VehicleEditViewModel : IValidatableObject
    {
        public Vehicle Vehicle { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }

        public IEnumerable<SelectListItem> Models { get; set; }

        public IEnumerable<SelectListItem> ConditionTypes { get; set; }

        public IEnumerable<SelectListItem> BodyStyles { get; set; }

        public IEnumerable<SelectListItem> Transmissions { get; set; }

        public IEnumerable<SelectListItem> ExteriorColors { get; set; }

        public IEnumerable<SelectListItem> InteriorColors { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Vehicle.VINNumber))
            {
                errors.Add(new ValidationResult("VINNumber is required."));
            }

            if (string.IsNullOrEmpty(Vehicle.Description))
            {
                errors.Add(new ValidationResult("Description is required."));
            }

            if (Vehicle.ConditionTypeID == 1)
            {
                if (Vehicle.Mileage < 0 || Vehicle.Mileage > 1000)
                {
                    errors.Add(new ValidationResult("New Vehicles mileage must be between 0 and 1000."));
                }
            }
            else
            {
                if (Vehicle.Mileage <= 1000)
                {
                    errors.Add(new ValidationResult("Used Vehicles mileage must be greater than 1000."));
                }
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".png", ".jpg", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a .png, .jpg, or .jpeg"));

                }
            }
            
            if (Vehicle.Year >= 2000 && Vehicle.Year <= 2023)
            {

            }
            else
            {
                errors.Add(new ValidationResult("Year must be between 2000 and 2023."));
            }

            if (Vehicle.Mileage < 0)
            {
                errors.Add(new ValidationResult("Mileage cannot be less than 0."));
            }

            if (Vehicle.MSRP <= 0)
            {
                errors.Add(new ValidationResult("MSRP must be greater than 0."));
            }

            if (Vehicle.SalePrice <= 0)
            {
                errors.Add(new ValidationResult("Sale Price must be greater than 0."));
            }

            if (Vehicle.SalePrice <= Vehicle.MSRP)
            {
                errors.Add(new ValidationResult("Vehicle Sale Price must be greater than MSRP."));
            }

            return errors;
        }
    }
}