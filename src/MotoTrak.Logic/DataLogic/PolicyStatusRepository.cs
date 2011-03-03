using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class PolicyStatusRepository : EntityRepository<PolicyStatusEntity>
    {
        public PolicyStatusEntity GetByCode(string code)
        {
            return Context.FindOne<PolicyStatusEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<PolicyStatusEntity> GetAll()
        {
            return Context.Find<PolicyStatusEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }
    }
}