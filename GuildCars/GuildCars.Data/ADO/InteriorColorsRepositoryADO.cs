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
    public class InteriorColorsRepositoryADO : IInteriorColorsRepository
    {
        public List<InteriorColor> GetAll()
        {
            List<InteriorColor> interiorColors = new List<InteriorColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColor currentRow = new InteriorColor();
                        currentRow.InteriorColorID = (int)dr["InteriorColorID"];
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();

                        interiorColors.Add(currentRow);

                    }
                }
            }

            return interiorColors;
        }
    }
}
