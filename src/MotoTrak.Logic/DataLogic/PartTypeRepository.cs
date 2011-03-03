using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class PartTypeRepository : EntityRepository<PartTypeEntity>
    {
        public PartTypeEntity GetByCode(string code)
        {
            return Context.FindOne<PartTypeEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<PartTypeEntity> GetAll()
        {
            return Context.Find<PartTypeEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }
    }
}