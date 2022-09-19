using GuildCars.Data.ADO;
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
    public class AdminAPIController : ApiController
    {
        [Route("api/admin/vehicles")]
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


        [Route("api/admin/model/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels(int id)
        {
            var repo = ModelsRepositoryFactory.GetRepository();

            try
            {

                var result = repo.GetModelsById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/makes")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetMakes()
        {

            var repo = MakesRepositoryFactory.GetRepository();

            try
            {

                var result = repo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/models")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels()
        {

            var repo = ModelsRepositoryFactory.GetRepository();

            try
            {

                var result = repo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/specials")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSpecials()
        {

            var repo = SpecialsRepositoryFactory.GetRepository();

            try
            {

                var result = repo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/specials/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteSpecial(int id)
        {

            var repo = SpecialsRepositoryFactory.GetRepository();

            try
            {

                repo.RemoveSpecial(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
