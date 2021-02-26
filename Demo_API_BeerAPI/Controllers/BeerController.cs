using Demo_API_Intro.Models;
using Demo_API_Intro.ModelsAPI;
using Demo_API_Intro.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo_API_Intro.Controllers
{
    [RoutePrefix("api/Beer")]
    public class BeerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FindAll([FromUri] PaginationParameter parameter)
        {
            IEnumerable<Beer> beers = BeerService.Instance.GetPagination(parameter.Offset, parameter.Limit);
            int totalBeer = BeerService.Instance.GetTotalBrand();

            return Json(new CollectionResponseAPI(totalBeer, beers));
        }

        [HttpGet]
        public IHttpActionResult FindBeerById(int id)
        {
            Beer beer = BeerService.Instance.GetOne(id);

            if (beer is null)
                return NotFound();

            return Json(beer);
        }

        [HttpGet]
        [Route("GetByCategories")]
        public IHttpActionResult FindBeerByCategories([FromUri] PaginationParameter parameter, [FromUri] string[] categories)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IHttpActionResult Insert(BeerData data)
        {
            if (data is null)
                return BadRequest("Data is required !");

            int newId = BeerService.Instance.Add(data);

            return Json(BeerService.Instance.GetOne(newId));
        }

        [HttpPut]
        public IHttpActionResult FullUpdate(int id, BeerData data)
        {
            if (data is null)
                return BadRequest("Data is required !");

            bool isUpdated = BeerService.Instance.Update(id, data);

            if (isUpdated)
            {
                return Json(BeerService.Instance.GetOne(id));
            }
            else
            {
                return BadRequest("An error occurred during the request");
            }
        }

        [HttpPatch]
        public IHttpActionResult PartialUpdate(int id, BeerPartialData data)
        {
            if (data is null)
                return BadRequest("Data is required !");

            Beer originalData = BeerService.Instance.GetOne(id);
            if(originalData is null) {
                return BadRequest("An error occurred during the request");
            }

            BeerData updateData = new BeerData()
            {
                Name = data.Name ?? originalData.Name,
                Color = data.Color ?? originalData.Color,
                Degree = data.Degree ?? originalData.Degree,
                IdBrewery = data.IdBrewery ?? originalData.Brewery.Id,
                IdBrand = data.IdBrand ?? originalData.Brand?.Id
            };
            bool isUpdated = BeerService.Instance.Update(id, updateData);

            if (isUpdated)
            {
                return Json(BeerService.Instance.GetOne(id));
            }
            else
            {
                return BadRequest("An error occurred during the request");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteBeer(int id)
        {
            bool isDeleted = BeerService.Instance.Delete(id);

            if (isDeleted)
                return Ok();

            return BadRequest("An error occurred during the request");
        }


        [HttpPost]
        [Route("{id}/AddCategory/{idCategory}")]
        public IHttpActionResult AddCategory(int id, int idCategory)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{id}/RemoveCategory/{idCategory}")]
        public IHttpActionResult RemoveCategory(int id, int idCategory)
        {
            throw new NotImplementedException();
        }
    }
}
