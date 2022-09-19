﻿using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class PurchasesRepositoryFactory
    {
        public static IPurchasesRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new PurchasesRepositoryADO();
                default:
                    throw new Exception("Could not find RepositoryType Configuration value.");
            }
        }
    }
}

