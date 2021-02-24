using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Database;
using Toolbox.Repository;

namespace Demo_API_BeerAPI.DAL.Repositories
{
    public abstract class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        protected ConnectDB ConnectDB { get; }

        protected string TableName { get; }
        protected string IdName { get; }

        public RepositoryBase(string tableName, string idName = "Id")
        {
            ConnectDB = new ConnectDB(ConfigurationManager.ConnectionStrings["db-source"].ConnectionString);

            TableName = tableName;
            IdName = idName;
        }

        protected abstract TEntity ConvertDataReaderToEntity(IDataReader reader);

        public virtual TEntity Get(TKey id)
        {
            QueryDB query = new QueryDB($"SELECT * FROM [{TableName}] WHERE [{IdName}] = @Id");
            query.AddParametre("@Id", id);

            return ConnectDB.ExecuteReader(query, ConvertDataReaderToEntity).SingleOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            QueryDB query = new QueryDB($"SELECT * FROM [{TableName}]");

            return ConnectDB.ExecuteReader(query, ConvertDataReaderToEntity);
        }

        public abstract TKey Insert(TEntity entity);

        public abstract bool Update(TKey id, TEntity entity);

        public virtual bool Delete(TKey id)
        {
            QueryDB query = new QueryDB($"DELETE FROM [{TableName}] WHERE [{IdName}] = @Id");
            query.AddParametre("@Id", id);

            return ConnectDB.ExecuteNonQuery(query) == 1;
        }
    }
}
