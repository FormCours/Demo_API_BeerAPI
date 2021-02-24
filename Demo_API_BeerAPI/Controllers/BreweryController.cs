using Demo_API_Intro.Models;
using Demo_API_Intro.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo_API_Intro.Controllers
{
    [RoutePrefix("api/Brewery")]
    public class BreweryController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult FindAll()
        {
            IEnumerable<Brewery> breweries = BreweryService.Instance.GetAll();
            int totalBrewery = BreweryService.Instance.GetTotalBrewery();

            // TODO Add Model for this
            return Json(new
            {
                total = totalBrewery,
                results = breweries
            });
        }

        [HttpGet]
        [Route("page")]
        public IHttpActionResult FindWithPagination([FromUri] int offset, [FromUri] int limit)
        {
            IEnumerable<Brewery> breweries = BreweryService.Instance.GetPagination(offset, limit);
            int totalBrewery = BreweryService.Instance.GetTotalBrewery();

            // TODO Add Model for this
            return Json(new
            {
                total = totalBrewery,
                results = breweries
            });
        }


        [HttpGet]
        public IHttpActionResult FindBreweryById(int id)
        {
            Brewery brewery = BreweryService.Instance.GetOne(id);

            if (brewery is null)
                return NotFound();

            return Json(brewery);
        }

        [HttpPost]
        public IHttpActionResult AddNewBrewery([FromBody] BreweryData data)
        {
            if (data is null)
                return BadRequest("Data is required !");

            if (BreweryService.Instance.Exists(data.Name))
                return BadRequest($"The brewery {data.Name} does already exists");

            int newId = BreweryService.Instance.Add(data);

            Brewery brewery = BreweryService.Instance.GetOne(newId);
            return Json(brewery);
        }

        [HttpPut]
        public IHttpActionResult UpdateBrewery(int id, [FromBody] BreweryData data)
        {
            if (data is null)
                return BadRequest("Data is required !");

            if (BreweryService.Instance.GetOne(id) is null)
                return BadRequest($"The brewery {id} does not exists");

            bool isUpdated = BreweryService.Instance.Update(id, data);

            if (isUpdated)
            {
                Brewery brewery = BreweryService.Instance.GetOne(id);
                return Json(brewery);
            }
            else
            {
                return BadRequest("An error occurred during the request");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteBrewery(int id)
        {
            bool isDeleted = BreweryService.Instance.Delete(id);

            if (isDeleted)
                return Ok();

            return BadRequest("An error occurred during the request");
        }
    }
}
