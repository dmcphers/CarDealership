using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IMakesRepository
    {
        List<Make> GetAll();
        Make GetByID(int id);
        void AddMake(Make make);
    }
}
