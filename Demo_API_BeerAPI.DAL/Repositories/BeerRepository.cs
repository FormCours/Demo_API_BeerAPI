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
    }
}
