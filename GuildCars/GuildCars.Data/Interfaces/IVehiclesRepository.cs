using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehiclesRepository
    {
        List<Vehicle> GetAll();
        Vehicle GetById(int vehicleID);
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(int vehicleID);
        IEnumerable<FeaturedVehicle> GetFeatured();
        VehicleItem GetDetails(int vehicleID);
        List<VehicleItem> SearchInventory(InventorySearchParameters parameters);
        List<VehicleItem> SearchInventoryAdmin(InventorySearchParameters parameters);
        List<InventoryReport> GetInventory(int conditionTypeID);

    }
}
