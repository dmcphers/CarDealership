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
    public class BodyStylesRepositoryADO : IBodyStylesRepository
    {
        public List<BodyStyle> GetAll()
        {
            List<BodyStyle> bodyStyles = new List<BodyStyle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStylesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle();
                        currentRow.BodyStyleID = (int)dr["BodyStyleID"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        
                        bodyStyles.Add(currentRow);
                    }
                }
            }

            return bodyStyles;
        }
    }
}
