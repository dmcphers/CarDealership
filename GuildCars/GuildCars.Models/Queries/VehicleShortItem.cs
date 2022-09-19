using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleShortItem
    {
        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int ConditionTypeID { get; set; }
        public string ConditionTypeName { get; set; }
        public int BodyStyleID { get; set; }
        public string BodyStyleName { get; set; }
        public int Year { get; set; }
        public int TransmissionID { get; set; }
        public string TransmissionName { get; set; }
        public int ExteriorColorID { get; set; }
        public string ExteriorColorName { get; set; }
        public int InteriorColorID { get; set; }
        public string InteriorColorName { get; set; }
        public int Mileage { get; set; }
        public string VINNumber { get; set; }
        public decimal? MSRP { get; set; }
        public decimal? SalePrice { get; set; }
        public string ImageFileName { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; } = false;
        public string Purchased { get; set; }
    }
}
