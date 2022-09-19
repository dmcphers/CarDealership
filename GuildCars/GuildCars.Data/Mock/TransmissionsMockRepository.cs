using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class TransmissionsMockRepository : ITransmissionsRepository
    {
        private static List<Transmission> transmissions = new List<Transmission>
        { new Transmission() { TransmissionID = 1, TransmissionName = "Automatic" },
            new Transmission() { TransmissionID = 2, TransmissionName = "Manual" }
        };
        public List<Transmission> GetAll()
        {
            return transmissions;
        }
    }
}
