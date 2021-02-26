using Demo_API_BeerAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Database;

namespace Demo_API_BeerAPI.DAL.Repositories
{
    public class BeerRepository : RepositoryBase<int, BeerEntity>
    {
        public BeerRepository() : base("Beer", "Id_Beer")
        { }

        public override IEnumerable<BeerEntity> GetPagination(int offset, int limit)
        {
            return base.GetPagination(offset, limit, "Name");
        }

        public override int Insert(BeerEntity entity)
        {
            QueryDB query = new QueryDB("InsertBeer", true);
            query.AddParametre("@Name", entity.Name);
            query.AddParametre("@Color", entity.Color);
            query.AddParametre("@Degree", entity.Degree);
            query.AddParametre("@Id_Brewery", entity.IdBrewery);
            query.AddParametre("@Id_Brand", entity.IdBrand);

            return (int)ConnectDB.ExecuteScalar(query);
        }

        public override bool Update(int id, BeerEntity entity)
        {
            QueryDB query = new QueryDB("UpdateBeer", true);
            query.AddParametre("@Id_Beer", id);
            query.AddParametre("@Name", entity.Name);
            query.AddParametre("@Color", entity.Color);
            query.AddParametre("@Degree", entity.Degree);
            query.AddParametre("@Id_Brewery", entity.IdBrewery);
            query.AddParametre("@Id_Brand", entity.IdBrand);

            try
            {
                return ConnectDB.ExecuteNonQuery(query) == 1;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        protected override BeerEntity ConvertDataReaderToEntity(IDataReader reader)
        {
            return new BeerEntity()
            {
                Id = Convert.ToInt32(reader["Id_Beer"]),
                Name = reader["Name"].ToString(),
                Color = Convert.IsDBNull(reader["Color"]) ? null : reader["Color"].ToString(),
                Degree = Convert.IsDBNull(reader["Degree"]) ? null : (double?)Convert.ToDouble(reader["Degree"]),
                IdBrewery = Convert.ToInt32(reader["Id_Brewery"]),
                IdBrand = Convert.IsDBNull(reader["Id_Brand"]) ? null : (int?)Convert.ToInt32(reader["Id_Brand"]),
            };
        }


        #region Manage "Many to Many" between Category and Beer
        public IEnumerable<BeerEntity> GetByCategory(IEnumerable<int> idsCategory, int offset, int limit)
        {
            if (idsCategory.Count() == 0)
                return new List<BeerEntity>();

            string filterCategory = String.Join(", ", idsCategory);

            QueryDB query = new QueryDB("SELECT DISTINCT B.*  " +
                                        "FROM [Beer] B " +
                                        "   JOIN [BeerCategory] BC ON B.Id_Beer = BC.Id_Beer " +
                                       $"WHERE BC.Id_Category IN ({filterCategory}) " +
                                        "ORDER BY B.Name ASC " +
                                        "OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY");
            query.AddParametre("@offset", offset);
            query.AddParametre("@limit", limit);

            return ConnectDB.ExecuteReader(query, ConvertDataReaderToEntity);
        }

        public bool AddBeerCategory(int idCategory, int idBeer)
        {
            // TODO : Use stored procedure
            QueryDB queryCheck = new QueryDB("SELECT Count(*) FROM [BeerCategory] WHERE Id_Category = @IdCat AND Id_Beer =  @IdBeer");
            queryCheck.AddParametre("@IdCat", idCategory);
            queryCheck.AddParametre("@IdBeer", idBeer);

            if ((int)ConnectDB.ExecuteScalar(queryCheck) != 0)
                return false;


            QueryDB query = new QueryDB("INSERT INTO [BeerCategory] (Id_Category, Id_Beer) VALUES (@IdCat, @IdBeer);");
            query.AddParametre("@IdCat", idCategory);
            query.AddParametre("@IdBeer", idBeer);

            return ConnectDB.ExecuteNonQuery(query) == 1;
        }

        public bool RemoveBeerCategory(int idCategory, int idBeer)
        {
            QueryDB query = new QueryDB("DELETE FROM [BeerCategory] WHERE Id_Category = @IdCat AND Id_Beer= @IdBeer;");
            query.AddParametre("@IdCat", idCategory);
            query.AddParametre("@IdBeer", idBeer);

            return ConnectDB.ExecuteNonQuery(query) == 1;
        }
        #endregion
    }
}
