using Demo_API_BeerAPI.DAL.Repositories;
using Demo_API_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.ServiceData
{
    public class BreweryService
    {
        #region Singleton
        private static Lazy<BreweryService> _Instance = new Lazy<BreweryService>(() => new BreweryService());
        public static BreweryService Instance { get { return _Instance.Value; } }
        #endregion

        private BreweryRepository breweryRepository; 

        private BreweryService()
        {
            breweryRepository = new BreweryRepository();
        }

        public IEnumerable<Brewery> GetAll()
        {
            return breweryRepository.GetAll().Select(b => new Brewery()
            {
                Id = b.Id,
                Name = b.Name,
                Headquarter = b.Headquarter,
                Country = b.Country
            });
        }

        public Brewery GetOne(int id)
        {
            Demo_API_BeerAPI.DAL.Entities.BreweryEntity b = breweryRepository.Get(id);

            return new Brewery()
            {
                Id = b.Id,
                Name = b.Name,
                Headquarter = b.Headquarter,
                Country = b.Country
            };
        }

        public int Add(BreweryData breweryData)
        {
            int newId = breweryRepository.Insert(new Demo_API_BeerAPI.DAL.Entities.BreweryEntity()
            {
                Name = breweryData.Name,
                Headquarter = breweryData.Headquarter,
                Country = breweryData.Country
            });

            return newId;
        }

        public bool Update(int id, BreweryData breweryData)
        {
            bool isUpdated = breweryRepository.Update(id, new Demo_API_BeerAPI.DAL.Entities.BreweryEntity()
            {
                Name = breweryData.Name,
                Headquarter = breweryData.Headquarter,
                Country = breweryData.Country
            });

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = breweryRepository.Delete(id);

            return isDeleted;
        }
    }
}