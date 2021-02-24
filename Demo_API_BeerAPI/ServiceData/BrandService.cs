using Demo_API_BeerAPI.DAL.Repositories;
using Demo_API_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.ServiceData
{
    public class BrandService
    {
        #region Singleton
        private static Lazy<BrandService> _Instance = new Lazy<BrandService>(() => new BrandService());
        public static BrandService Instance { get { return _Instance.Value; } }
        #endregion

        private BrandRepository brandRepository;

        private BrandService()
        {
            brandRepository = new BrandRepository();
        }

        public IEnumerable<Brand> GetAll()
        {
            return brandRepository.GetAll().Select(b => new Brand()
            {
                Id = b.Id,
                Name = b.Name,
                Country = b.Country,
                CreationYear = b.CreationYear
            });
        }

        public Brand GetOne(int id)
        {
            Demo_API_BeerAPI.DAL.Entities.BrandEntity b = brandRepository.Get(id);

            return new Brand()
            {
                Id = b.Id,
                Name = b.Name,
                Country = b.Country,
                CreationYear = b.CreationYear
            };
        }

        public bool Exists(string brandName)
        {
            IEnumerable<Brand> brands = GetAll();

            return brands.Any(b => b.Name.Trim().ToLower() == brandName.Trim().ToLower());
        }

        public int Add(BrandData brandData)
        {
            int newId = brandRepository.Insert(new Demo_API_BeerAPI.DAL.Entities.BrandEntity()
            {
                Name = brandData.Name,
                Country = brandData.Country,
                CreationYear = brandData.CreationYear
            });

            return newId;
        }

        public bool Update(int id, BrandData brandData)
        {
            bool isUpdated = brandRepository.Update(id, new Demo_API_BeerAPI.DAL.Entities.BrandEntity()
            {
                Name = brandData.Name,
                Country = brandData.Country,
                CreationYear = brandData.CreationYear
            });

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = brandRepository.Delete(id);

            return isDeleted;
        }
    }
}