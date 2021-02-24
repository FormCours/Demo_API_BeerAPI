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
    [RoutePrefix("api/Beer")]
    public class BeerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FindAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult FindBeerById(int id)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("GetByCategories")]
        public IHttpActionResult FindBeerByCategories([FromUri] string[] categories)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public IHttpActionResult Insert(Beer beer)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IHttpActionResult FullUpdate(int id, Beer beer)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IHttpActionResult PartialUpdate(int id, Beer beer)
        {
            throw new NotImplementedException();
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
