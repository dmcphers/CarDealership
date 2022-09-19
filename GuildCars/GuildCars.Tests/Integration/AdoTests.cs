using GuildCars.Data.ADO;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.Integration
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepositoryADO();

            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count);

            Assert.AreEqual("KY", states[0].StateID);
            Assert.AreEqual("Kentucky", states[0].StateName);
        }

        [Test]
        public void CanLoadPurchaseTypes()
        {
            var repo = new PurchaseTypesRepositoryADO();

            var purchaseTypes = repo.GetAll();

            Assert.AreEqual(3, purchaseTypes.Count);

            Assert.AreEqual(1, purchaseTypes[0].PurchaseTypeID);
            Assert.AreEqual("Bank Finance", purchaseTypes[0].PurchaseTypeName);
        }


        [Test]
        public void CanLoadPurchases()
        {
            var repo = new PurchasesRepositoryADO();

            var purchases = repo.GetAll();

            Assert.AreEqual(3, purchases.Count);

            Assert.AreEqual(1, purchases[0].PurchaseID);
            Assert.AreEqual("Gregor Gibbe", purchases[0].Name);
        }


        [Test]
        public void CanLoadContacts()
        {
            var repo = new ContactsRepositoryADO();

            var contacts = repo.GetAll();

            Assert.AreEqual(3, contacts.Count);

            Assert.AreEqual(1, contacts[0].ContactID);
            Assert.AreEqual("Brad Smith", contacts[0].ContactName);
        }


        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialsRepositoryADO();

            var specials = repo.GetAll();

            Assert.AreEqual(3, specials.Count);

            Assert.AreEqual(3, specials[0].SpecialID);
            Assert.AreEqual("New Year Deal", specials[0].SpecialTitle);
        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new BodyStylesRepositoryADO();

            var bodyStyles = repo.GetAll();

            Assert.AreEqual(4, bodyStyles.Count);

            Assert.AreEqual(2, bodyStyles[1].BodyStyleID);
            Assert.AreEqual("SUV", bodyStyles[1].BodyStyleName);
        }


        [Test]
        public void CanLoadConditionTypes()
        {
            var repo = new ConditionTypesRepositoryADO();

            var conditionTypes = repo.GetAll();

            Assert.AreEqual(2, conditionTypes.Count);

            Assert.AreEqual(2, conditionTypes[1].ConditionTypeID);
            Assert.AreEqual("Used", conditionTypes[1].ConditionTypeName);
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = new ModelsRepositoryADO();

            var models = repo.GetAll();

            Assert.AreEqual(3, models.Count);

            Assert.AreEqual(2, models[1].ModelID);
            Assert.AreEqual("Mustang", models[1].ModelName);
        }

        [Test]
        public void CanLoadMakes()
        {
            var repo = new MakesRepositoryADO();

            var makes = repo.GetAll();

            Assert.AreEqual(3, makes.Count);

            Assert.AreEqual(2, makes[1].MakeID);
            Assert.AreEqual("Ford", makes[1].MakeName);
        }

        [Test]
        public void CanLoadTransmissions()
        {
            var repo = new TransmissionsRepositoryADO();

            var transmissions = repo.GetAll();

            Assert.AreEqual(2, transmissions.Count);

            Assert.AreEqual(2, transmissions[1].TransmissionID);
            Assert.AreEqual("Manual", transmissions[1].TransmissionName);
        }


        [Test]
        public void CanLoadExteriorColors()
        {
            var repo = new ExteriorColorsRepositoryADO();

            var exteriorColors = repo.GetAll();

            Assert.AreEqual(5, exteriorColors.Count);

            Assert.AreEqual(4, exteriorColors[3].ExteriorColorID);
            Assert.AreEqual("Red", exteriorColors[3].ExteriorColorName);
        }

        [Test]
        public void CanLoadInteriorColors()
        {
            var repo = new InteriorColorsRepositoryADO();

            var interiorColors = repo.GetAll();

            Assert.AreEqual(5, interiorColors.Count);

            Assert.AreEqual(1, interiorColors[4].InteriorColorID);
            Assert.AreEqual("White", interiorColors[4].InteriorColorName);
        }

        
        [Test]
        public void CanLoadVehicle()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicle = repo.GetById(1);

            Assert.IsNotNull(vehicle);

            Assert.AreEqual(1, vehicle.VehicleID);
            Assert.AreEqual(1, vehicle.MakeID);
            Assert.AreEqual(1, vehicle.ModelID);
            Assert.AreEqual(1, vehicle.ConditionTypeID);
            Assert.AreEqual(1, vehicle.BodyStyleID);
            Assert.AreEqual(2014, vehicle.Year);
            Assert.AreEqual(1, vehicle.TransmissionID);
            Assert.AreEqual(5, vehicle.ExteriorColorID);
            Assert.AreEqual(2, vehicle.InteriorColorID);
            Assert.AreEqual(16253, vehicle.Mileage);
            Assert.AreEqual("WAUKG78E56A885549", vehicle.VINNumber);
            Assert.AreEqual(39584M, vehicle.MSRP);
            Assert.AreEqual(37656, vehicle.SalePrice);
            Assert.AreEqual("Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.", vehicle.Description);
            Assert.AreEqual("placeholder.png", vehicle.ImageFileName);
        }

        [Test]
        public void NotFoundVehicleReturnsNull()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicle = repo.GetById(1000);

            Assert.IsNull(vehicle);
        }

        [Test]
        public void CanAddVehicle()
        {

            Vehicle vehicleToAdd = new Vehicle();
            
            var repo = new VehiclesRepositoryADO();

            vehicleToAdd.MakeID = 1;
            vehicleToAdd.ModelID = 2;
            vehicleToAdd.ConditionTypeID = 2;
            vehicleToAdd.BodyStyleID = 3;
            vehicleToAdd.Year = 2000;
            vehicleToAdd.TransmissionID = 1;
            vehicleToAdd.ExteriorColorID = 3;
            vehicleToAdd.InteriorColorID = 2;
            vehicleToAdd.Mileage = 4444;
            vehicleToAdd.VINNumber = "JM1NCOOO1F0384655";
            vehicleToAdd.MSRP = 28000M;
            vehicleToAdd.SalePrice = 26000M;
            vehicleToAdd.Description = "This car has had one owner and has been kept in a garage";
            vehicleToAdd.ImageFileName = "snazzycar.jpg";
            vehicleToAdd.Featured = true;

            repo.Insert(vehicleToAdd);

            Assert.AreEqual(14, vehicleToAdd.VehicleID);
        }

        [Test]
        public void CanUpdateVehicle()
        {

            Vehicle vehicleToAdd = new Vehicle();

            var repo = new VehiclesRepositoryADO();

            vehicleToAdd.MakeID = 1;
            vehicleToAdd.ModelID = 2;
            vehicleToAdd.ConditionTypeID = 2;
            vehicleToAdd.BodyStyleID = 3;
            vehicleToAdd.Year = 2000;
            vehicleToAdd.TransmissionID = 1;
            vehicleToAdd.ExteriorColorID = 3;
            vehicleToAdd.InteriorColorID = 2;
            vehicleToAdd.Mileage = 4444;
            vehicleToAdd.VINNumber = "JM1NCOOO1F0384655";
            vehicleToAdd.MSRP = 28000M;
            vehicleToAdd.SalePrice = 26000M;
            vehicleToAdd.Description = "This car has had one owner and has been kept in a garage";
            vehicleToAdd.ImageFileName = "snazzycar.jpg";
            vehicleToAdd.Featured = true;

            repo.Insert(vehicleToAdd);

            vehicleToAdd.MakeID = 2;
            vehicleToAdd.ModelID = 3;
            vehicleToAdd.ConditionTypeID = 1;
            vehicleToAdd.BodyStyleID = 4;
            vehicleToAdd.Year = 2010;
            vehicleToAdd.TransmissionID = 2;
            vehicleToAdd.ExteriorColorID = 2;
            vehicleToAdd.InteriorColorID = 4;
            vehicleToAdd.Mileage = 3333;
            vehicleToAdd.VINNumber = "J123COOO1F0384655";
            vehicleToAdd.MSRP = 38000M;
            vehicleToAdd.SalePrice = 35000M;
            vehicleToAdd.Description = "This car has had one owner and was driven in very rough conditions";
            vehicleToAdd.ImageFileName = "roughcar.jpg";
            vehicleToAdd.Featured = false;

            repo.Update(vehicleToAdd);

            var updatedVehicle = repo.GetById(14);

            Assert.AreEqual(2, updatedVehicle.MakeID);
            Assert.AreEqual(3, updatedVehicle.ModelID);
            Assert.AreEqual(1, updatedVehicle.ConditionTypeID);
            Assert.AreEqual(4, updatedVehicle.BodyStyleID);
            Assert.AreEqual(2010, updatedVehicle.Year);
            Assert.AreEqual(2, updatedVehicle.TransmissionID);
            Assert.AreEqual(2, updatedVehicle.ExteriorColorID);
            Assert.AreEqual(4, updatedVehicle.InteriorColorID);
            Assert.AreEqual(3333, updatedVehicle.Mileage);
            Assert.AreEqual("J123COOO1F0384655", updatedVehicle.VINNumber);
            Assert.AreEqual(38000M, updatedVehicle.MSRP);
            Assert.AreEqual(35000M, updatedVehicle.SalePrice);
            Assert.AreEqual("This car has had one owner and was driven in very rough conditions", updatedVehicle.Description);
            Assert.AreEqual("roughcar.jpg", updatedVehicle.ImageFileName);
            Assert.AreEqual(false, updatedVehicle.Featured);
        }

        [Test]
        public void CanLoadVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetAll();

            Assert.AreEqual(13, vehicles.Count);

            Assert.AreEqual(13, vehicles[3].VehicleID);
            Assert.AreEqual(8425, vehicles[4].Mileage);
        }

        [Test]
        public void CanDeleteVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();

            var repo = new VehiclesRepositoryADO();

            vehicleToAdd.MakeID = 1;
            vehicleToAdd.ModelID = 2;
            vehicleToAdd.ConditionTypeID = 2;
            vehicleToAdd.BodyStyleID = 3;
            vehicleToAdd.Year = 2000;
            vehicleToAdd.TransmissionID = 1;
            vehicleToAdd.ExteriorColorID = 3;
            vehicleToAdd.InteriorColorID = 2;
            vehicleToAdd.Mileage = 4444;
            vehicleToAdd.VINNumber = "JM1NCOOO1F0384655";
            vehicleToAdd.MSRP = 28000M;
            vehicleToAdd.SalePrice = 26000M;
            vehicleToAdd.Description = "This car has had one owner and has been kept in a garage";
            vehicleToAdd.ImageFileName = "snazzycar.jpg";
            vehicleToAdd.Featured = true;

            repo.Insert(vehicleToAdd);

            var loaded = repo.GetById(14);
            Assert.IsNotNull(loaded);
            repo.Delete(14);
            loaded = repo.GetById(14);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanLoadFeaturedVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            List<FeaturedVehicle> featuredVehicles = repo.GetFeatured().ToList();

            Assert.AreEqual(5, featuredVehicles.Count());

            Assert.AreEqual(13, featuredVehicles[0].VehicleID);
            Assert.AreEqual(1, featuredVehicles[0].MakeID);
            Assert.AreEqual("Buick", featuredVehicles[0].MakeName);
            Assert.AreEqual(1, featuredVehicles[0].ModelID);
            Assert.AreEqual("Regal", featuredVehicles[0].ModelName);
            Assert.AreEqual(25999, featuredVehicles[0].SalePrice);
            Assert.AreEqual("placeholder.png", featuredVehicles[0].ImageFileName);
            Assert.AreEqual(2009, featuredVehicles[0].Year);

        }

        [Test]
        public void CanLoadVehicleDetails()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicleItem = repo.GetDetails(1);

            Assert.IsNotNull(vehicleItem);

            Assert.AreEqual(1, vehicleItem.VehicleID);
            Assert.AreEqual(1, vehicleItem.MakeID);
            Assert.AreEqual("Buick", vehicleItem.MakeName);
            Assert.AreEqual(1, vehicleItem.ModelID);
            Assert.AreEqual("Regal", vehicleItem.ModelName);
            Assert.AreEqual(1, vehicleItem.ConditionTypeID);
            Assert.AreEqual("New", vehicleItem.ConditionTypeName);
            Assert.AreEqual(1, vehicleItem.BodyStyleID);
            Assert.AreEqual("Car", vehicleItem.BodyStyleName);
            Assert.AreEqual(2014, vehicleItem.Year);
            Assert.AreEqual(1, vehicleItem.TransmissionID);
            Assert.AreEqual("Automatic", vehicleItem.TransmissionName);
            Assert.AreEqual(5, vehicleItem.ExteriorColorID);
            Assert.AreEqual("Blue", vehicleItem.ExteriorColorName);
            Assert.AreEqual(2, vehicleItem.InteriorColorID);
            Assert.AreEqual("Black", vehicleItem.InteriorColorName);
            Assert.AreEqual(16253, vehicleItem.Mileage);
            Assert.AreEqual("WAUKG78E56A885549", vehicleItem.VINNumber);
            Assert.AreEqual(39584M, vehicleItem.MSRP);
            Assert.AreEqual(37656M, vehicleItem.SalePrice);
            Assert.AreEqual("Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.", vehicleItem.Description);
            Assert.AreEqual("placeholder.png", vehicleItem.ImageFileName);
        }

        [Test]
        public void CanAddContacts()
        {
            var repo = new ContactsRepositoryADO();
            Contact contact = new Contact();

            contact.ContactName = "Bert Samuel";
            contact.EmailAddress = "bert@email.com";
            contact.PhoneNumber = "2543784738";
            contact.Message = "I like the Lincoln";

            repo.AddContact(contact);

            var contacts = repo.GetAll();

            Assert.AreEqual(4, contacts.Count());
        }

        [Test]
        public void CanSearchOnMinPrice()
        {
            var repo = new VehiclesRepositoryADO();

            var found = repo.SearchInventory(new InventorySearchParameters { MinPrice = 30000M });

            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void CanSearchOnMaxPrice()
        {
            var repo = new VehiclesRepositoryADO();

            var found = repo.SearchInventory(new InventorySearchParameters { MaxPrice = 30000M });

            Assert.AreEqual(11, found.Count());
        }

        [Test]
        public void CanSearchOnPriceRange()
        {
            var repo = new VehiclesRepositoryADO();

            var found = repo.SearchInventory(new InventorySearchParameters { MinPrice = 25000M, MaxPrice = 30000M });

            Assert.AreEqual(9, found.Count());
        }

        [Test]
        public void CanDoQuickSearch()
        {
            var repo = new VehiclesRepositoryADO();

            var found = repo.SearchInventory(new InventorySearchParameters { QuickSearch = "2020" });

            Assert.AreEqual(3, found.Count());
        }
    }
}
