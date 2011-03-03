using System;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class UserRepository : EntityRepository<UserEntity>
    {
        public UserEntity GetByCode(string code)
        {
            return Context.FindOne<UserEntity>(x => x.Code == code && x.IsActive == true);
        }

        public void UpdateLastLogin(int id)
        {
            var cmd = Context.Sql.Update("dbo.Users")
                             .Set("LastLoginDate", DateTime.Now)
                             .Where("Id", Criteria.IsEqualTo(id))
                             .Build();

            cmd.ExecuteNonQuery();
        }
    }
}