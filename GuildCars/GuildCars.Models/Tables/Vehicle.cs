using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int ConditionTypeID { get; set; }
        public int BodyStyleID { get; set; }
        public int Year { get; set; }
        public int TransmissionID { get; set; }
        public int ExteriorColorID { get; set; }
        public int InteriorColorID { get; set; }
        public int Mileage { get; set; }

        [Required]
        public string VINNumber { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageFileName { get; set; }
        public bool Featured { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
