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
    public class CategoryController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FindAll()
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public IHttpActionResult Find(int id)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public IHttpActionResult InsertCategory(Category category)
        {
            throw new NotImplementedException();
        }


        [HttpPut, HttpPatch]
        public IHttpActionResult UpdateCategory(int id, Category category)
        {
            throw new NotImplementedException();
        }


        [HttpDelete] 
        public IHttpActionResult RemoveCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
