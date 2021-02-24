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
    public class BreweryController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FindAll()
        {
            IEnumerable<Brewery> breweries = BreweryService.Instance.GetAll();

            return Json(breweries);
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
        public IHttpActionResult AddNewBrewery(BreweryData data)
        {
            if(BreweryService.Instance.Exists(data.Name))
                return BadRequest($"The brewery {data.Name} does already exists");

            int newId = BreweryService.Instance.Add(data);

            Brewery brewery = BreweryService.Instance.GetOne(newId);
            return Json(brewery);
        }

        [HttpPut]
        public IHttpActionResult UpdateBrewery(int id, BreweryData data)
        {
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
