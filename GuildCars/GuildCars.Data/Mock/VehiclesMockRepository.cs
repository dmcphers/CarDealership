using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class VehiclesMockRepository : IVehiclesRepository
    {
        public List<Vehicle> _vehicles;
        public VehiclesMockRepository()
        {
            _vehicles = new List<Vehicle>

            {
                new Vehicle
                {
                    VehicleID = 1,
                    MakeID = 1,
                    ModelID = 1,
                    ConditionTypeID = 1,
                    BodyStyleID = 1,
                    Year = 2013,
                    TransmissionID = 1,
                    ExteriorColorID = 2,
                    InteriorColorID = 3,
                    Mileage = 1000,
                    VINNumber = "1000asdf34j3l3kj",
                    MSRP = 11000M,
                    SalePrice = 10000M,
                    Description = "A lovely new demo car",
                    ImageFileName = "placeholder.png",
                    Featured = true,
                    CreatedDate = Convert.ToDateTime("12/10/2021")
                },
                new Vehicle
                {
                    VehicleID = 2,
                    MakeID = 2,
                    ModelID = 3,
                    ConditionTypeID = 2,
                    BodyStyleID = 2,
                    Year = 2014,
                    TransmissionID = 2,
                    ExteriorColorID = 3,
                    InteriorColorID = 2,
                    Mileage = 10000,
                    VINNumber = "1034asdf34j3l3kj",
                    MSRP = 8000M,
                    SalePrice = 7500M,
                    Description = "A lovely used demo car",
                    ImageFileName = "placeholder.png",
                    Featured = true,
                    CreatedDate = Convert.ToDateTime("12/10/2021")
                }
            };
        }

        static List<Make> makes = new MakesMockRepository().GetAll();
        static List<Model> models = new ModelsMockRepository().GetAll();
        static List<BodyStyle> bodyStyles = new BodyStylesMockRepository().GetAll();
        static List<Transmission> transmissions = new TransmissionsMockRepository().GetAll();
        static List<ExteriorColor> exteriorColors = new ExteriorColorsMockRepository().GetAll();
        static List<InteriorColor> interiorColors = new InteriorColorsMockRepository().GetAll();
        static List<ConditionType> conditionTypes = new ConditionTypesMockRepository().GetAll();


        //public void Delete(int vehicleID)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Vehicle> GetAll()
        //{
        //    return _vehicles;
        //}

        //public Vehicle GetById(int vehicleID)
        //{
        //    throw new NotImplementedException();
        //}

        //public VehicleItem GetDetails(int vehicleID)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<FeaturedVehicle> GetFeatured()
        {
            //List<Vehicle> listFeaturedVehicles = _vehicles.Where(v => v.Featured == true);

            List<FeaturedVehicle> IEFeaturedVehicles = new List<FeaturedVehicle>();
            foreach (var lfv in _vehicles)
            {
                if (lfv.Featured == true)
                {
                    FeaturedVehicle row = new FeaturedVehicle();
                    row.ImageFileName = lfv.ImageFileName;
                    row.Year = lfv.Year;
                    Make make = makes.First(m => m.MakeID == lfv.MakeID);
                    row.MakeName = make.MakeName;
                    Model model = models.First(models => models.ModelID == lfv.ModelID);
                    row.ModelName = model.ModelName;
                    row.SalePrice = lfv.SalePrice;

                    IEFeaturedVehicles.Add(row);
                }
            }
            //List<FeaturedVehicle> featuredVehicles = from v in _vehicles
            //where Featured == true
            //select v.ImageFileName;

            //           List<FeaturedVehicle> featuredVehicles = SELECT TOP 5 VehicleID, Vehicles.MakeID, Makes.MakeName, Vehicles.ModelID, Models.ModelName, SalePrice, ImageFileName, [Year]

            //           FROM((Vehicles

            //   INNER JOIN Makes ON Vehicles.MakeID = Makes.MakeID)

            //   INNER JOIN Models ON Makes.MakeID = Models.MakeID)
            //WHERE Vehicles.Featured = 1

            //   ORDER BY Vehicles.Mileage


            return IEFeaturedVehicles;
        }

        //public List<InventoryReport> GetInventory(int conditionTypeID)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert(Vehicle vehicle)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<VehicleShortItem> SearchInventory(InventorySearchParameters parameters)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Vehicle vehicle)
        //{
        //    throw new NotImplementedException();
        //}


        public void Delete(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public VehicleItem GetDetails(int vehicleID)
        {
            throw new NotImplementedException();
        }


        public List<InventoryReport> GetInventory(int conditionTypeID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<VehicleItem> GetVehicleItems()
        {
            
                List<VehicleItem> vehicleItems =
                    (from v in _vehicles
                    join mk in makes on v.MakeID equals mk.MakeID
                    join mo in models on v.ModelID equals mo.ModelID
                    join bs in bodyStyles on v.BodyStyleID equals bs.BodyStyleID
                    join t in transmissions on v.TransmissionID equals t.TransmissionID
                    join ec in exteriorColors on v.ExteriorColorID equals ec.ExteriorColorID
                    join ic in interiorColors on v.InteriorColorID equals ic.InteriorColorID
                    join ct in conditionTypes on v.ConditionTypeID equals ct.ConditionTypeID
                    select new VehicleItem()
                    {
                        VehicleID = v.VehicleID,
                        MakeID = v.MakeID,
                        ModelID = v.ModelID,
                        ModelName = mo.ModelName,
                        MakeName = mk.MakeName,
                        ConditionTypeID = v.ConditionTypeID,
                        ConditionTypeName = ct.ConditionTypeName,
                        BodyStyleID = v.BodyStyleID,
                        BodyStyleName = bs.BodyStyleName,
                        Year = v.Year,
                        TransmissionID = v.TransmissionID,
                        TransmissionName = t.TransmissionName,
                        ExteriorColorID = v.ExteriorColorID,
                        ExteriorColorName = ec.ExteriorColorName,
                        InteriorColorID = ic.InteriorColorID,
                        InteriorColorName = ic.InteriorColorName,
                        Mileage = v.Mileage,
                        VINNumber = v.VINNumber,
                        MSRP = v.MSRP,
                        SalePrice = v.SalePrice,
                        ImageFileName = v.ImageFileName,
                        Description = v.Description,
                        Featured = v.Featured
                    }).ToList();
                //vehicleItems.Add(vi);
            

            return vehicleItems;
            //return (from v in _vehicles
            //        join mk in makes on v.MakeID equals mk.MakeID
            //        join mo in models on v.ModelID equals mo.ModelID
            //        join bs in bodyStyles on v.BodyStyleID equals bs.BodyStyleID
            //        join t in transmissions on v.TransmissionID equals t.TransmissionID
            //        join ec in exteriorColors on v.ExteriorColorID equals ec.ExteriorColorID
            //        join ic in interiorColors on v.InteriorColorID equals ic.InteriorColorID
            //        join ct in conditionTypes on v.ConditionTypeID equals ct.ConditionTypeID
            //        select new VehicleItem()
            //        {
            //            VehicleID = v.VehicleID,
            //            MakeID = v.MakeID,
            //            ModelID = v.ModelID,
            //            ModelName = mo.ModelName,
            //            MakeName = mk.MakeName,
            //            ConditionTypeID = v.ConditionTypeID,
            //            ConditionTypeName = ct.ConditionTypeName,
            //            BodyStyleID = v.BodyStyleID,
            //            BodyStyleName = bs.BodyStyleName,
            //            Year = v.Year,
            //            TransmissionID = v.TransmissionID,
            //            TransmissionName = t.TransmissionName,
            //            ExteriorColorID = v.ExteriorColorID,
            //            ExteriorColorName = ec.ExteriorColorName,
            //            InteriorColorID = v.InteriorColorID,
            //            InteriorColorName = ic.InteriorColorName,
            //            Mileage = v.Mileage,
            //            VINNumber = v.VINNumber,
            //            MSRP = v.MSRP,
            //            SalePrice = v.SalePrice,
            //            ImageFileName = v.ImageFileName,
            //            Description = v.Description,
            //            Featured = v.Featured
            //        }).ToList();
        }

        public List<VehicleItem> GenerateVehicleShortItems()
        {
            List<VehicleItem> vehicleItems = GetVehicleItems();
            List<VehicleItem> vehicleShortItems = new List<VehicleItem>();

            foreach (var veh in vehicleItems)
            {
                VehicleItem vs = (from ve in vehicleItems
                                       select new VehicleItem()
                                       {
                                           VehicleID = veh.VehicleID,
                                           ModelID = veh.ModelID,
                                           MakeID = veh.MakeID,
                                           ConditionTypeID = veh.ConditionTypeID,
                                           BodyStyleID = veh.BodyStyleID,
                                           TransmissionID = veh.TransmissionID,
                                           ExteriorColorID = veh.ExteriorColorID,
                                           InteriorColorID = veh.InteriorColorID,
                                           Mileage = veh.Mileage,
                                           Year = veh.Year,
                                           MSRP = veh.MSRP,
                                           SalePrice = veh.SalePrice,
                                           ImageFileName = veh.ImageFileName,
                                           MakeName = veh.MakeName,
                                           ModelName = veh.ModelName,
                                           ConditionTypeName = veh.ConditionTypeName,
                                           BodyStyleName = veh.BodyStyleName,
                                           TransmissionName = veh.TransmissionName,
                                           ExteriorColorName = veh.ExteriorColorName,
                                           InteriorColorName = veh.InteriorColorName,
                                           Purchased = "1"
                                       }).First();
                vehicleShortItems.Add(vs);
            }

            return vehicleShortItems;

        }
        public List<VehicleItem> SearchInventory(InventorySearchParameters parameters)
        {

            List<VehicleItem> shortList = new List<VehicleItem>();
            List<VehicleItem> shortListCond = new List<VehicleItem>();
            List<VehicleItem> output = new List<VehicleItem>();

            if (parameters.ConditionTypeName == null)
            {
                shortList = GenerateVehicleShortItems();
            }

            else
            {
                //shortList = GenerateVehicleShortItems().Where(v => v.ConditionTypeName == parameters.ConditionTypeName).ToList();
                shortList = GenerateVehicleShortItems();
                shortListCond = (from vehi in shortList
                                 where vehi.ConditionTypeName == parameters.ConditionTypeName
                                 select vehi).ToList();


            }


            if (parameters.QuickSearch != null)
            {

                output.AddRange(shortList.Where(v => v.MakeName.Contains(parameters.QuickSearch) || v.ModelName.Contains(parameters.QuickSearch) || v.Year.ToString().Contains(parameters.QuickSearch.ToString())));
            }

            else if (parameters.MinPrice != null)
            {
                output.AddRange(shortList.Where(v => v.SalePrice >= parameters.MinPrice));
            }

            else if (parameters.MaxPrice != null)
            {
                output.AddRange(shortList.Where(v => v.SalePrice <= parameters.MaxPrice));
            }

            else if (parameters.MinYear != null)
            {
                output.AddRange(shortList.Where(v => v.Year >= parameters.MinYear));
            }

            else if (parameters.MaxYear != null)
            {
                output.AddRange(shortList.Where(v => v.Year <= parameters.MaxYear));
            }

            else output = shortListCond;

            return output;


        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<VehicleItem> SearchInventoryAdmin(InventorySearchParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
