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

        private BeerService()
        { }


        public IEnumerable<Beer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Beer Get(int id)
        {
            throw new NotImplementedException();
        }

        public Beer Insert(Beer beer)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Beer beer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}