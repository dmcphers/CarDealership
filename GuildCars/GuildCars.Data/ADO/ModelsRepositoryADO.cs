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
    public class ModelsRepositoryADO : IModelsRepository
    {
        public void AddModel(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeID", model.MakeID);
                cmd.Parameters.AddWithValue("@UserID", model.UserID);
                cmd.Parameters.AddWithValue("@EmailAddress", model.Email);
                cmd.Parameters.AddWithValue("@MakeName", model.MakeName);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Model> GetAll()
        {
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.CreatedDate = (DateTime)dr["CreatedDate"];
                        currentRow.Email = dr["EmailAddress"].ToString();

                        models.Add(currentRow);

                    }
                }
            }

            return models;
        }

        public List<Model> GetModelsById(int makeID)
        {

            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelectByMakeID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeID", makeID);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.UserID = dr["UserID"].ToString();

                        models.Add(currentRow);

                    }
                }
            }

            return models;
        }
    }
}
