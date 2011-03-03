using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class ClaimTypeRepository : EntityRepository<ClaimTypeEntity>
    {
        public ClaimTypeEntity GetByCode(string code)
        {
            return Context.FindOne<ClaimTypeEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<ClaimTypeEntity> GetAll()
        {
            return Context.Find<ClaimTypeEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }
    }
}