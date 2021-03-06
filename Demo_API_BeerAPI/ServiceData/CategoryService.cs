﻿using Demo_API_BeerAPI.DAL.Repositories;
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

        private CategoryRepository categoryRepository;

        private CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }


        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll().Select(c => new Category()
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public Category GetOne(int id)
        {
            Demo_API_BeerAPI.DAL.Entities.CategoryEntity category = categoryRepository.Get(id);

            if (category is null)
                return null;

            return new Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public int Add(CategoryData categoryData)
        {
            int newId = categoryRepository.Insert(new Demo_API_BeerAPI.DAL.Entities.CategoryEntity()
            {
                Name = categoryData.Name
            });

            return newId;
        }

        public bool Update(int id, Category categoryData)
        {
            bool isUpdated = categoryRepository.Update(id, new Demo_API_BeerAPI.DAL.Entities.CategoryEntity()
            {
                Name = categoryData.Name
            });

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = categoryRepository.Delete(id);

            return isDeleted;
        }


        #region Link bewteen Beer and Category
        public IEnumerable<Category> GetCategoriesOfBeer(int idBeer)
        {
            return categoryRepository.GetBeerCategories(idBeer).Select(c => new Category()
            {
                Id = c.Id,
                Name = c.Name
            });
        }
        #endregion
    }
}