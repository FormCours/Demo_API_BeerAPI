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
    public class BreweryRepository : RepositoryBase<int, BreweryEntity>
    {
        public BreweryRepository() : base("Brewery", "Id_Brewery") 
        { }

        public IEnumerable<BreweryEntity> GetPagination(int offset, int limit)
        {
            QueryDB query = new QueryDB("SELECT * FROM [Brewery] " +
                                        "ORDER BY [Name] ASC " +
                                        "OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY");
            query.AddParametre("@offset", offset);
            query.AddParametre("@limit", limit);

            return ConnectDB.ExecuteReader(query, ConvertDataReaderToEntity);
        }

        public override int Insert(BreweryEntity entity)
        {
            QueryDB query = new QueryDB("InsertBrewery", true);
            query.AddParametre("@Name", entity.Name);
            query.AddParametre("@Headquarter", entity.Headquarter);
            query.AddParametre("@Country", entity.Country);

            return (int) ConnectDB.ExecuteScalar(query);
        }

        public override bool Update(int id, BreweryEntity entity)
        {
            QueryDB query = new QueryDB("UpdateBrewery", true);
            query.AddParametre("@Id_Brewery", id);
            query.AddParametre("@Name", entity.Name);
            query.AddParametre("@Headquarter", entity.Headquarter);
            query.AddParametre("@Country", entity.Country);

            try
            {
                return ConnectDB.ExecuteNonQuery(query) == 1;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        protected override BreweryEntity ConvertDataReaderToEntity(IDataReader reader)
        {
            return new BreweryEntity()
            {
                Id = Convert.ToInt32(reader["Id_Brewery"]),
                Name = reader["Name"].ToString(),
                Headquarter = (reader["Headquarter"] is DBNull) ? null : reader["Headquarter"].ToString(),
                Country = (reader["Country"] is DBNull) ? null : reader["Country"].ToString()
            };
        }
    }
}
