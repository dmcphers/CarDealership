using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class InteriorColorsRepositoryFactory
    {
        public static IInteriorColorsRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new InteriorColorsRepositoryADO();
                default:
                    throw new Exception("Could not find RepositoryType Configuration value.");
            }
        }
    }
}
