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
    public class CategoryController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FindAll()
        {
            List<Category> categories = CategoryService.Instance.GetAll().ToList();

            return Json(new CollectionResponseAPI(categories.Count, categories));
        }


        [HttpGet]
        public IHttpActionResult FindCategoryById(int id)
        {
            Category category = CategoryService.Instance.GetOne(id);

            if (category is null)
                return NotFound();

            return Json(category);
        }


        [HttpPost]
        public IHttpActionResult AddCategory([FromBody]CategoryData catData)
        {
            if (catData is null)
                return BadRequest("Data is required !");

            int newId = CategoryService.Instance.Add(catData);

            return Json(CategoryService.Instance.GetOne(newId));
        }


        [HttpDelete] 
        public IHttpActionResult RemoveCategory(int id)
        {
            // TODO : Error if try to remove category linked with beer !

            bool isDeleted = CategoryService.Instance.Delete(id);

            if (isDeleted)
                return Ok();

            return BadRequest("An error occurred during the request");
        }
    }
}
