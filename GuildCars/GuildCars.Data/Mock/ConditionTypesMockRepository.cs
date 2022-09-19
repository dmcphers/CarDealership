using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class ConditionTypesMockRepository : IConditionTypesRepository
    {
        private static List<ConditionType> conditionTypes = new List<ConditionType> 
        { new ConditionType() { ConditionTypeID = 1, ConditionTypeName = "New" }, 
            new ConditionType() { ConditionTypeID = 2, ConditionTypeName = "Used" } };
        public List<ConditionType> GetAll()
        {
            return conditionTypes;
        }
    }
}
