using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class LanguageRepository : EntityRepository<LanguageEntity>
    {
        public LanguageEntity GetByCode(string code)
        {
            return Context.FindOne<LanguageEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<LanguageEntity> GetAll()
        {
            return Context.Find<LanguageEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }
    }
}