using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class ReportsAPIController : ApiController
    {
        ApplicationDbContext _context;
        IPurchasesRepository _purchasesRepository;
        IVehiclesRepository _vehiclesRepository;

        
        public ReportsAPIController(IPurchasesRepository purchasesRepository, IVehiclesRepository vehiclesRepository)
        {
            _purchasesRepository = purchasesRepository;
            _vehiclesRepository = vehiclesRepository;
            _context = new ApplicationDbContext();

        }

        public ReportsAPIController()
        {
            _context = new ApplicationDbContext();

        }

        [Route("api/Reports/Sales")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Sales(string user, DateTime? fromDate, DateTime? toDate)
        {
            var repo = PurchasesRepositoryFactory.GetRepository();

            try
            {
                var parameters = new SalesReportSearchParameters()
                {
                    UserName = user,
                    FromDate = fromDate,
                    ToDate = toDate
                };

                List<SalesReport> result = new List<SalesReport>();

                result = repo.GetSales(parameters);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Reports/Inventory/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Inventory(int id)
        {
            var repo = VehiclesRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetInventory(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
