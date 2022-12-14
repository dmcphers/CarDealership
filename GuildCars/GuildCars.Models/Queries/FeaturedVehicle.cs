using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class FeaturedVehicle
    {
        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public decimal SalePrice { get; set; }
        public string ImageFileName { get; set; }
        public int Year { get; set; }
    }
}
