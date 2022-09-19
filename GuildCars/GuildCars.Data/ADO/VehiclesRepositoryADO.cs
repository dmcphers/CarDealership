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
    public class VehiclesRepositoryADO : IVehiclesRepository
    {
        public void Delete(int vehicleID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VehicleID = (int)dr["VehicleID"];
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.ConditionTypeID = (int)dr["ConditionTypeID"];
                        currentRow.BodyStyleID = (int)dr["BodyStyleID"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.TransmissionID = (int)dr["TransmissionID"];
                        currentRow.InteriorColorID = (int)dr["InteriorColorID"];
                        currentRow.ExteriorColorID = (int)dr["ExteriorColorID"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.VINNumber = dr["VINNumber"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.CreatedDate = (DateTime)dr["CreatedDate"];

                        vehicles.Add(currentRow);

                    }
                }
            }

            return vehicles;
        }

        public Vehicle GetById(int vehicleID)
        {
            Vehicle vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.MakeID = (int)dr["MakeID"];
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.ConditionTypeID = (int)dr["ConditionTypeID"];
                        vehicle.BodyStyleID = (int)dr["BodyStyleID"];
                        vehicle.Year = (int)dr["Year"];
                        vehicle.TransmissionID = (int)dr["TransmissionID"];
                        vehicle.ExteriorColorID = (int)dr["ExteriorColorID"];
                        vehicle.InteriorColorID = (int)dr["InteriorColorID"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.VINNumber = dr["VINNumber"].ToString();
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();

                        if (dr["SalePrice"] != DBNull.Value)
                            vehicle.SalePrice = (decimal)dr["SalePrice"];
                        if (dr["Featured"] != DBNull.Value)
                            vehicle.Featured = (bool)dr["Featured"];

                    }
                }
            }

            return vehicle;
        }

        public VehicleItem GetDetails(int vehicleID)
        {
            VehicleItem vehicleItem = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicleItem = new VehicleItem();
                        vehicleItem.VehicleID = (int)dr["VehicleID"];
                        vehicleItem.MakeID = (int)dr["MakeID"];
                        vehicleItem.MakeName = dr["MakeName"].ToString();
                        vehicleItem.ModelID = (int)dr["ModelID"];
                        vehicleItem.ModelName = dr["ModelName"].ToString();
                        vehicleItem.ConditionTypeID = (int)dr["ConditionTypeID"];
                        vehicleItem.ConditionTypeName = dr["ConditionTypeName"].ToString();
                        vehicleItem.BodyStyleID = (int)dr["BodyStyleID"];
                        vehicleItem.BodyStyleName = dr["BodyStyleName"].ToString();
                        vehicleItem.Year = (int)dr["Year"];
                        vehicleItem.TransmissionID = (int)dr["TransmissionID"];
                        vehicleItem.TransmissionName = dr["TransmissionName"].ToString();
                        vehicleItem.ExteriorColorID = (int)dr["ExteriorColorID"];
                        vehicleItem.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        vehicleItem.InteriorColorID = (int)dr["InteriorColorID"];
                        vehicleItem.InteriorColorName = dr["InteriorColorName"].ToString();
                        vehicleItem.Mileage = (int)dr["Mileage"];
                        vehicleItem.VINNumber = dr["VINNumber"].ToString();
                        vehicleItem.MSRP = (decimal)dr["MSRP"];
                        vehicleItem.Description = dr["Description"].ToString();
                        vehicleItem.ImageFileName = dr["ImageFileName"].ToString();
                        vehicleItem.Purchased = dr["PurchaseID"].ToString();

                        if (dr["SalePrice"] != DBNull.Value)
                            vehicleItem.SalePrice = (decimal)dr["SalePrice"];
                        if (dr["Featured"] != DBNull.Value)
                            vehicleItem.Featured = (bool)dr["Featured"];
                        if (dr["PurchaseID"].ToString() == "")
                        {
                            vehicleItem.Purchased = "0";
                        }
                        else
                        {
                            vehicleItem.Purchased = "1";
                        }

                    }
                }
            }

            return vehicleItem;
        }

        public IEnumerable<FeaturedVehicle> GetFeatured()
        {

            List<FeaturedVehicle> featuredVehicles = new List<FeaturedVehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicle row = new FeaturedVehicle();

                        row.VehicleID = (int)dr["VehicleID"];
                        row.MakeID = (int)dr["MakeID"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelID = (int)dr["ModelID"];
                        row.ModelName = dr["ModelName"].ToString();

                        if (dr["SalePrice"] != DBNull.Value)
                            row.SalePrice = (decimal)dr["SalePrice"];

                        row.ImageFileName = dr["ImageFileName"].ToString();
                        row.Year = (int)dr["Year"];

                        featuredVehicles.Add(row);
                    }
                }
            }

            return featuredVehicles;
        }

        public void Insert(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@ConditionTypeID", vehicle.ConditionTypeID);
                cmd.Parameters.AddWithValue("@BodyStyleID", vehicle.BodyStyleID);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@ExteriorColorID", vehicle.ExteriorColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColorID);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VINNumber", vehicle.VINNumber);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);

                if (string.IsNullOrEmpty(vehicle.ImageFileName))
                {
                    cmd.Parameters.AddWithValue("@ImageFileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                }
                
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleID = (int)param.Value;
            }
        }

        public List<VehicleItem> SearchInventory(InventorySearchParameters parameters)
        {
            List<VehicleItem> vehicles = new List<VehicleItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchInventory", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@QuickSearch", parameters.QuickSearch);
                cmd.Parameters.AddWithValue("@ConditionTypeName", parameters.ConditionTypeName);
                cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice);
                cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleItem row = new VehicleItem ();
                        row.VehicleID = (int)dr["VehicleID"];
                        row.Year = (int)dr["Year"];
                        row.MakeID = (int)dr["MakeID"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelID = (int)dr["ModelID"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.ImageFileName = dr["ImageFileName"].ToString();
                        row.BodyStyleName = dr["BodyStyleName"].ToString();
                        row.TransmissionName = dr["TransmissionName"].ToString();
                        row.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        row.InteriorColorName = dr["InteriorColorName"].ToString();
                        row.Mileage = (int)dr["Mileage"];
                        row.VINNumber = dr["VINNumber"].ToString();

                        if (dr["SalePrice"] != DBNull.Value)
                            row.SalePrice = (decimal)dr["SalePrice"];
                        if (dr["MSRP"] != DBNull.Value)
                        {
                            row.MSRP = (decimal)dr["MSRP"];
                        }
                        
                        vehicles.Add(row);
                    }
                }
            }

            return vehicles;

        }


        public List<VehicleItem> SearchInventoryAdmin(InventorySearchParameters parameters)
        {
            List<VehicleItem> vehicles = new List<VehicleItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchInventoryAdmin", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@QuickSearch", parameters.QuickSearch);
                cmd.Parameters.AddWithValue("@ConditionTypeName", parameters.ConditionTypeName);
                cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice);
                cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleItem row = new VehicleItem();
                        row.VehicleID = (int)dr["VehicleID"];
                        row.Year = (int)dr["Year"];
                        row.MakeID = (int)dr["MakeID"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelID = (int)dr["ModelID"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.ImageFileName = dr["ImageFileName"].ToString();
                        row.BodyStyleName = dr["BodyStyleName"].ToString();
                        row.TransmissionName = dr["TransmissionName"].ToString();
                        row.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        row.InteriorColorName = dr["InteriorColorName"].ToString();
                        row.Mileage = (int)dr["Mileage"];
                        row.VINNumber = dr["VINNumber"].ToString();

                        if (dr["SalePrice"] != DBNull.Value)
                            row.SalePrice = (decimal)dr["SalePrice"];
                        if (dr["MSRP"] != DBNull.Value)
                        {
                            row.MSRP = (decimal)dr["MSRP"];
                        }
                        
                        vehicles.Add(row);
                    }
                }
            }

            return vehicles;

        }


        
        public void Update(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@ConditionTypeID", vehicle.ConditionTypeID);
                cmd.Parameters.AddWithValue("@BodyStyleID", vehicle.BodyStyleID);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@ExteriorColorID", vehicle.ExteriorColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColorID);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VINNumber", vehicle.VINNumber);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<InventoryReport> GetInventory(int conditionTypeID)
        {
            List<InventoryReport> inventoryRecords = new List<InventoryReport>();



            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventoryReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("ConditionTypeID", conditionTypeID);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport currentRow = new InventoryReport();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (decimal)dr["StockValue"];
                        currentRow.ConditionTypeID = (int)dr["ConditionTypeID"];
                        currentRow.ConditionTypeName = dr["ConditionTypeName"].ToString();

                        inventoryRecords.Add(currentRow);

                    }
                }
                
                return inventoryRecords;
            }
        }

        public IEnumerable<Vehicle> GetFeaturedMock()
        {
            throw new NotImplementedException();
        }
    }
}
