using Demo_API_BeerAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Database;

namespace Demo_API_BeerAPI.DAL.Repositories
{
    public class MemberRepository : RepositoryBase<int, MemberEntity>
    {
        public MemberRepository() : base("V_Member", "Id_Member")
        { }

        public override int Insert(MemberEntity entity)
        {
            QueryDB query = new QueryDB("InsertMember", true);
            query.AddParametre("@Username", entity.Username);
            query.AddParametre("@Email", entity.Email);
            query.AddParametre("@Password", entity.Password);

            return (int) ConnectDB.ExecuteScalar(query);
        }

        public MemberEntity GetByCredential(string email, string password)
        {
            QueryDB query = new QueryDB("RetrieveMember", true);
            query.AddParametre("@Email", email);
            query.AddParametre("@Password", password);

            return ConnectDB.ExecuteReader(query, ConvertDataReaderToEntity).SingleOrDefault();
        }

        public override bool Update(int id, MemberEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override MemberEntity ConvertDataReaderToEntity(IDataReader reader)
        {
            return new MemberEntity()
            {
                Id = Convert.ToInt32(reader["Id_Member"]),
                Username = reader["Username"].ToString(),
                Email = reader["Email"].ToString(),
                Password = null,
                Role = reader["Role"].ToString()
            };
        }
    }
}
