using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("api/Inventory/New")]
        [AcceptVerbs("GET")]
        public IHttpActionResult InventoryNew(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string quickSearch)
        {
            var repo = VehiclesRepositoryFactory.GetRepository();

            try
            {
                var parameters = new InventorySearchParameters()
                {
                    QuickSearch = quickSearch,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinYear = minYear,
                    MaxYear = maxYear,
                    ConditionTypeName = "New"

                };

                var result = repo.SearchInventory(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Inventory/Used")]
        [AcceptVerbs("GET")]
        public IHttpActionResult InventoryUsed(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string quickSearch)
        {
            var repo = VehiclesRepositoryFactory.GetRepository();

            try
            {
                var parameters = new InventorySearchParameters()
                {
                    QuickSearch = quickSearch,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinYear = minYear,
                    MaxYear = maxYear,
                    ConditionTypeName = "Used"

                };

                var result = repo.SearchInventory(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
