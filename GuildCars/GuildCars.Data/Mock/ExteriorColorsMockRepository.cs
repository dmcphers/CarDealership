using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class ExteriorColorsMockRepository : IExteriorColorsRepository
    {
        private static List<ExteriorColor> exteriorColors = new List<ExteriorColor>
        { new ExteriorColor() { ExteriorColorID = 1, ExteriorColorName = "Blue" },
            new ExteriorColor() { ExteriorColorID = 2, ExteriorColorName = "Black" },
            new ExteriorColor() { ExteriorColorID = 3, ExteriorColorName = "White" }
        };
        public List<ExteriorColor> GetAll()
        {
            return exteriorColors;
        }
    }
}
