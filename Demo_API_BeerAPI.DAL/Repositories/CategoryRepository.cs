using Demo_API_BeerAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Database;

namespace Demo_API_BeerAPI.DAL.Repositories
{
    public class CategoryRepository : RepositoryBase<int, CategoryEntity>
    {
        public CategoryRepository() : base("Category", "Id_Category")
        { }


        public override int Insert(CategoryEntity entity)
        {
            QueryDB query = new QueryDB("InsertCategory", true);
            query.AddParametre("@Name", entity.Name);

            return (int)ConnectDB.ExecuteScalar(query);
        }

        public override bool Update(int id, CategoryEntity entity)
        {
            QueryDB query = new QueryDB("UpdateCategory", true);
            query.AddParametre("@Id_Category", id);
            query.AddParametre("@Name", entity.Name);

            try
            {
                return ConnectDB.ExecuteNonQuery(query) == 1;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        protected override CategoryEntity ConvertDataReaderToEntity(IDataReader reader)
        {
            return new CategoryEntity()
            {
                Id = Convert.ToInt32(reader["Id_Category"]),
                Name = reader["Name"].ToString()
            };
        }


        #region Manage "Many to Many" between Category and Beer
        public IEnumerable<CategoryEntity> GetBeerCategories(int idBeer)
        {
            QueryDB query = new QueryDB("SELECT * " +
                                       $"FROM [Category] C JOIN [BeerCategory] BC ON C.Id_category = BC.Id_category " +
                                        "WHERE [Id_Beer] = @IdBeer");
            query.AddParametre("@IdBeer", idBeer);

            return ConnectDB.ExecuteReader(query, ConvertDataReaderToEntity);
        }
        #endregion
    }
}
