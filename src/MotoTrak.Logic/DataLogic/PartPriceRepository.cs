using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class PartPriceRepository : EntityRepository<PartPriceEntity>
    {
        public List<PartPriceEntity> GetByPart(int partId)
        {
            return Context.Find<PartPriceEntity>()
                          .Where(x => x.PartId == partId && x.IsActive == true)
                          .OrderAsc(x => x.EffectiveDate)
                          .List();
        }

        public PartPriceEntity GetPrice(int partId, DateTime effectiveDate)
        {
            return Context.Find<PartPriceEntity>()
                          .Top(1)
                          .Where(x => x.PartId == partId && x.EffectiveDate <= effectiveDate && x.IsActive == true)
                          .OrderDesc(x => x.EffectiveDate)
                          .Single();
        }
    }
}