using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class ClaimStatusRepository : EntityRepository<ClaimStatusEntity>
    {
        public ClaimStatusEntity GetByCode(string code)
        {
            return Context.FindOne<ClaimStatusEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<ClaimStatusEntity> GetAll()
        {
            return Context.Find<ClaimStatusEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }
    }
}