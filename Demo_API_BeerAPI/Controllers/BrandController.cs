﻿using Demo_API_Intro.Models;
using Demo_API_Intro.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo_API_Intro.Controllers
{
    public class BrandController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FindAll()
        {
            IEnumerable<Brand> brands = BrandService.Instance.GetAll();

            return Json(brands);
        }

        [HttpGet]
        public IHttpActionResult FindBrandById(int id)
        {
            Brand brand = BrandService.Instance.GetOne(id);

            if (brand is null)
                return NotFound();

            return Json(brand);
        }

        [HttpPost]
        public IHttpActionResult AddNewBrand(BrandData data)
        {
            if(BrandService.Instance.Exists(data.Name))
                return BadRequest($"The brand {data.Name} already exists");

            int newId = BrandService.Instance.Add(data);

            return Json(BrandService.Instance.GetOne(newId));
        }

        [HttpPut]
        public IHttpActionResult UpdateBrand(int id, BrandData data)
        {
            if (BrandService.Instance.GetOne(id) is null)
                return BadRequest($"The brand '{id}' does not exists");

            bool isUpdated = BrandService.Instance.Update(id, data);

            if (isUpdated)
            {
                return Json(BrandService.Instance.GetOne(id));
            }
            else
            {
                return BadRequest("An error occurred during the request");
            }
        }

        [HttpDelete] 
        public IHttpActionResult DeleteBrand(int id)
        {
            bool isDeleted = BrandService.Instance.Delete(id);

            if (isDeleted)
                return Ok();

            return BadRequest("An error occurred during the request");
        }
    }
}