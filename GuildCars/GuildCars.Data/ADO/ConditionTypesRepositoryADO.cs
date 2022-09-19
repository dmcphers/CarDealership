using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class ConditionTypesRepositoryADO : IConditionTypesRepository
    {
        public List<ConditionType> GetAll()
        {
            List<ConditionType> conditionTypes = new List<ConditionType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ConditionTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ConditionType currentRow = new ConditionType();
                        currentRow.ConditionTypeID = (int)dr["ConditionTypeID"];
                        currentRow.ConditionTypeName = dr["ConditionTypeName"].ToString();

                        conditionTypes.Add(currentRow);
                    }
                }
            }

            return conditionTypes;
        }
    }
}
