using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class ModelsMockRepository : IModelsRepository
    {
        private static List<Model> models = new List<Model>
        { new Model() { ModelID = 1, ModelName = "Regal" },
            new Model() { ModelID = 2, ModelName = "Mustang" },
            new Model() { ModelID = 3, ModelName = "Civic" }
        };
        public void AddModel(Model model)
        {
            throw new NotImplementedException();
        }

        public List<Model> GetAll()
        {
            return models;
        }

        public List<Model> GetModelsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
