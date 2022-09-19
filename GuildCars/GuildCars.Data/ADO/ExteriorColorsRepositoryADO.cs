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
    public class ExteriorColorsRepositoryADO : IExteriorColorsRepository
    {
        public List<ExteriorColor> GetAll()
        {
            List<ExteriorColor> exteriorColors = new List<ExteriorColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ExteriorColor currentRow = new ExteriorColor();
                        currentRow.ExteriorColorID = (int)dr["ExteriorColorID"];
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();

                        exteriorColors.Add(currentRow);

                    }
                }
            }

            return exteriorColors;
        }
    }
}
