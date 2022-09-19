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
    public class SalesAPIController : ApiController
    {
        [Route("api/sales/index")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetInventory(decimal? minPrice, decimal? maxPrice, string quickSearch, int? maxYear, int? minYear)
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
                    ConditionTypeName = null

                };


                var result = repo.SearchInventoryAdmin(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
