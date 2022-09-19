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
    public class TransmissionsRepositoryADO : ITransmissionsRepository
    {
        public List<Transmission> GetAll()
        {
            List<Transmission> transmissions = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission currentRow = new Transmission();
                        currentRow.TransmissionID = (int)dr["TransmissionID"];
                        currentRow.TransmissionName = dr["TransmissionName"].ToString();
                        
                        transmissions.Add(currentRow);

                    }
                }
            }

            return transmissions;
        }
    }
}
