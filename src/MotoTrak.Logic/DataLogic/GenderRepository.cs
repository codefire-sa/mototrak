using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class GenderRepository : EntityRepository<GenderEntity>
    {
        public GenderEntity GetByCode(string code)
        {
            return Context.FindOne<GenderEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<GenderEntity> GetAll()
        {
            return Context.Find<GenderEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }
    }
}