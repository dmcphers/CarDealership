using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class VehiclesAPIController : ApiController
    {
        [Route("api/vehicles/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string quickSearch)
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
