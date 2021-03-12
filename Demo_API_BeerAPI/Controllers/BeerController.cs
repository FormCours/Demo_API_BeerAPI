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
            IEnumerable<Category> selectedCategory = CategoryService.Instance.GetAll()
                                                        .Where(sc => categories.Any(c => c.ToLower() == sc.Name.ToLower()));

            IEnumerable<Beer> beers = BeerService.Instance.GetByCategories(selectedCategory, parameter.Offset, parameter.Limit);
            int totalBeer = BeerService.Instance.GetTotalBrand();

            return Json(new CollectionResponseAPI(totalBeer, beers));
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Insert(BeerData data)
        {
            if (data is null)
                return BadRequest("Data is required !");

            int newId = BeerService.Instance.Add(data);

            return Json(BeerService.Instance.GetOne(newId));
        }

        [HttpPut]
        [Authorize]
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
        [Authorize]
        public IHttpActionResult PartialUpdate(int id, BeerPartialData data)
        {
            if (data is null)
                return BadRequest("Data is required !");

            Beer originalData = BeerService.Instance.GetOne(id);
            if (originalData is null)
            {
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
        [Authorize]
        public IHttpActionResult DeleteBeer(int id)
        {
            bool isDeleted = BeerService.Instance.Delete(id);

            if (isDeleted)
                return Ok();

            return BadRequest("An error occurred during the request");
        }


        [HttpPost]
        [Route("{id}/AddCategory/{idCategory}")]
        [Authorize]
        public IHttpActionResult AddCategory(int id, int idCategory)
        {
            Beer target = BeerService.Instance.GetOne(id);
            Category category = CategoryService.Instance.GetOne(idCategory);

            if (target is null || category is null)
                return BadRequest("Invalid object !");

            if (target.Categories.Any(b => b.Id == idCategory))
                return BadRequest("The category is already added !");


            bool isAdded = BeerService.Instance.AddCategory(idCategory, id);

            if (isAdded)
                return Ok();

            return BadRequest();
        }

        [HttpPost]
        [Route("{id}/RemoveCategory/{idCategory}")]
        [Authorize]
        public IHttpActionResult RemoveCategory(int id, int idCategory)
        {
            Beer target = BeerService.Instance.GetOne(id);
            Category category = CategoryService.Instance.GetOne(idCategory);

            if (target is null || category is null)
                return BadRequest("Invalid object !");

            bool isRemoved = BeerService.Instance.RemoveCategory(idCategory, id);

            if (isRemoved)
                return Ok();

            return BadRequest();
        }
    }
}
