using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public static class VehiclesRepositoryFactory
    {
        public static IVehiclesRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new VehiclesRepositoryADO();
                case "QA":
                    return new VehiclesMockRepository();
                default:
                    throw new Exception("Could not find RepositoryType Configuration value.");
            }
        }
    }
}
