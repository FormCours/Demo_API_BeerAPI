using Demo_API_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.ServiceData
{
    public class CategoryService
    {
        #region Singleton
        private static Lazy<CategoryService> _Instance = new Lazy<CategoryService>(() => new CategoryService());
        public static CategoryService Instance { get { return _Instance.Value; } }
        #endregion


        private CategoryService()
        { }

        #region Crud
        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public Category Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Category category)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}