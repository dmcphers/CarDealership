using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<FeaturedVehicle> featured { get; set; }
        public IEnumerable<Special> specials { get; set; }
    }
}