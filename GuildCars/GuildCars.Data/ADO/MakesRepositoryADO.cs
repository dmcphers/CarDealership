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
    public class MakesRepositoryADO : IMakesRepository
    {
        public List<Make> GetAll()
        {
            List<Make> makes = new List<Make>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.CreatedDate = (DateTime)dr["CreatedDate"];
                        currentRow.Email = dr["EmailAddress"].ToString();

                        makes.Add(currentRow);

                    }
                }
            }

            return makes;
        }


        public Make GetByID(int id)
        {
            Make make = new Make();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeID", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        make.MakeID = (int)dr["MakeID"];
                        make.MakeName = dr["MakeName"].ToString();
                        make.CreatedDate = (DateTime)dr["CreatedDate"];
                        make.Email = dr["EmailAddress"].ToString();
                    }
                }
            }

            return make;
        }
            public void AddMake(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@EmailAddress", make.Email);
                cmd.Parameters.AddWithValue("@UserID", make.UserID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
