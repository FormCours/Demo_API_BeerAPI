using Demo_API_BeerAPI.DAL.Repositories;
using Demo_API_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.ServiceData
{
    public class BeerService
    {
        #region Singleton
        private static Lazy<BeerService> _Instance = new Lazy<BeerService>(() => new BeerService());
        public static BeerService Instance { get { return _Instance.Value; } }
        #endregion

        private BeerRepository beerRepository;

        private BeerService()
        {
            beerRepository = new BeerRepository();
        }


        public int GetTotalBrand()
        {
            return beerRepository.Count();
        }

        public IEnumerable<Beer> GetPagination(int offset, int limit)
        {
            IEnumerable<Demo_API_BeerAPI.DAL.Entities.BeerEntity> beersDB = beerRepository.GetPagination(offset, limit).ToList();

            foreach (var b in beersDB)
            {
                yield return ConvertBeerDB(b);
            }
        }

        public Beer GetOne(int id)
        {
            Demo_API_BeerAPI.DAL.Entities.BeerEntity beerDB = beerRepository.Get(id);

            return beerDB is null ? null : ConvertBeerDB(beerDB);
        }

        public IEnumerable<Beer> GetByCategories(IEnumerable<Category> categories, int offset, int limit)
        {
            if (categories.Count() == 0)
                return new List<Beer>();

            return beerRepository.GetByCategory(categories.Select(c => c.Id), offset, limit).Select(b => ConvertBeerDB(b));
        }

        public int Add(BeerData beerData)
        {
            int newId = beerRepository.Insert(new Demo_API_BeerAPI.DAL.Entities.BeerEntity()
            {
                Name = beerData.Name,
                Color = beerData.Color,
                Degree = beerData.Degree,
                IdBrewery = beerData.IdBrewery,
                IdBrand = beerData.IdBrand
            });

            return newId;
        }

        public bool Update(int id, BeerData beerData)
        {
            bool isUpdated = beerRepository.Update(id, new Demo_API_BeerAPI.DAL.Entities.BeerEntity()
            {
                Name = beerData.Name,
                Color = beerData.Color,
                Degree = beerData.Degree,
                IdBrewery = beerData.IdBrewery,
                IdBrand = beerData.IdBrand
            });

            return isUpdated;
        }

        public bool Delete(int id)
        {
            return beerRepository.Delete(id);
        }


        public bool AddCategory(int idCategory, int idBeer)
        {
            return beerRepository.AddBeerCategory(idCategory, idBeer);
        }

        public bool RemoveCategory(int idCategory, int idBeer)
        {
            return beerRepository.RemoveBeerCategory(idCategory, idBeer);
        }


        #region Mapper
        private Beer ConvertBeerDB(Demo_API_BeerAPI.DAL.Entities.BeerEntity beerDB)
        {
            Brewery brewery = BreweryService.Instance.GetOne(beerDB.IdBrewery);
            Brand brand = beerDB.IdBrand is null ? null : BrandService.Instance.GetOne((int)beerDB.IdBrand);
            IEnumerable<Category> categories = CategoryService.Instance.GetCategoriesOfBeer(beerDB.Id);

            return new Beer()
            {
                Id = beerDB.Id,
                Name = beerDB.Name,
                Color = beerDB.Color,
                Degree = beerDB.Degree,
                Brewery = brewery,
                Brand = brand,
                Categories = categories
            };
        }
        #endregion
    }
}