using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class InteriorColorsMockRepository : IInteriorColorsRepository
    {
        private static List<InteriorColor> interiorColors = new List<InteriorColor>
        { new InteriorColor() { InteriorColorID = 1, InteriorColorName = "Red" },
            new InteriorColor() { InteriorColorID = 2, InteriorColorName = "Green" },
            new InteriorColor() { InteriorColorID = 3, InteriorColorName = "Orange" }
        };
        public List<InteriorColor> GetAll()
        {
            return interiorColors;
        }
    }
}
