using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class MakesMockRepository : IMakesRepository
    {
        private static List<Make> makes = new List<Make>
        { new Make() { MakeID = 1, MakeName = "Buick" },
            new Make() { MakeID = 2, MakeName = "Ford" },
            new Make() { MakeID = 3, MakeName = "Honda" }
        };
        public void AddMake(Make make)
        {
            throw new NotImplementedException();
        }

        public List<Make> GetAll()
        {
            return makes; ;
        }

        public Make GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
