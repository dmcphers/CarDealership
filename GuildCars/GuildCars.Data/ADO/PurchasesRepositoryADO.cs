using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
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
    public class PurchasesRepositoryADO : IPurchasesRepository
    {
        public List<Purchase> GetAll()
        {
            List<Purchase> purchases = new List<Purchase>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchasesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Purchase currentRow = new Purchase();
                        currentRow.PurchaseID = (int)dr["PurchaseID"];
                        currentRow.VehicleID = (int)dr["VehicleID"];
                        currentRow.UserID = dr["UserID"].ToString();
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.EmailAddress = dr["EmailAddress"].ToString();
                        currentRow.PhoneNumber = dr["PhoneNumber"].ToString();
                        currentRow.StreetAddress1 = dr["StreetAddress1"].ToString();
                        currentRow.StreetAddress2 = dr["StreetAddress2"].ToString();
                        currentRow.City = dr["City"].ToString();
                        currentRow.StateID = dr["StateID"].ToString();
                        currentRow.Zipcode = dr["Zipcode"].ToString();
                        currentRow.PurchasePrice = (decimal)dr["PurchasePrice"];
                        currentRow.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        currentRow.PurchaseDate = (DateTime)dr["PurchaseDate"];

                        purchases.Add(currentRow);
                    }
                }
            }

            return purchases;
        }

        public void AddPurchase(Purchase purchase)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", purchase.VehicleID);
                cmd.Parameters.AddWithValue("@UserID", purchase.UserID);
                cmd.Parameters.AddWithValue("@Name", purchase.Name);
                cmd.Parameters.AddWithValue("@EmailAddress", purchase.EmailAddress);
                cmd.Parameters.AddWithValue("@PhoneNumber", purchase.PhoneNumber);
                cmd.Parameters.AddWithValue("@StreetAddress1", purchase.StreetAddress1);
                cmd.Parameters.AddWithValue("@StreetAddress2", purchase.StreetAddress2);
                cmd.Parameters.AddWithValue("@City", purchase.City);
                cmd.Parameters.AddWithValue("@StateID", purchase.StateID);
                cmd.Parameters.AddWithValue("@ZipCode", purchase.Zipcode);
                cmd.Parameters.AddWithValue("@PurchasePrice", purchase.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeID", purchase.PurchaseTypeID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<SalesReport> GetSales(SalesReportSearchParameters parameters)
        {
            List<SalesReport> sales = new List<SalesReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", parameters.UserName);
                cmd.Parameters.AddWithValue("@FromDate", parameters.FromDate);
                cmd.Parameters.AddWithValue("@toDate", parameters.ToDate);


                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReport currentRow = new SalesReport();
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];
                        currentRow.TotalSales = (decimal)dr["TotalSales"];

                        sales.Add(currentRow);
                    }
                }

                return sales;
            }
        }
    }
}
