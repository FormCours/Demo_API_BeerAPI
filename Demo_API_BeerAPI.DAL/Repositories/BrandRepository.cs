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
    public class BrandRepository : RepositoryBase<int, BrandEntity>
    {
        public BrandRepository() : base("Brand", "Id_Brand") 
        { }


        public override int Insert(BrandEntity entity)
        {
            QueryDB query = new QueryDB("InsertBrand", true);
            query.AddParametre("@Name", entity.Name);
            query.AddParametre("@Country", entity.Country);
            query.AddParametre("@Creation_Year", entity.CreationYear);

            return (int) ConnectDB.ExecuteScalar(query);
        }

        public override bool Update(int id, BrandEntity entity)
        {
            QueryDB query = new QueryDB("UpdateBrand", true);
            query.AddParametre("@Id_Brand", id);
            query.AddParametre("@Name", entity.Name);
            query.AddParametre("@Country", entity.Country);
            query.AddParametre("@Creation_Year", entity.CreationYear);

            try
            {
                return ConnectDB.ExecuteNonQuery(query) == 1;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        protected override BrandEntity ConvertDataReaderToEntity(IDataReader reader)
        {
            return new BrandEntity()
            {
                Id = Convert.ToInt32(reader["Id_Brand"]),
                Name = reader["Name"].ToString(),
                Country = (reader["Country"] is DBNull) ? null : reader["Country"].ToString(),
                CreationYear = (reader["Creation_Year"] is DBNull) ? null : (int?)Convert.ToInt32(reader["Creation_Year"])
            };
        }
    }
}
