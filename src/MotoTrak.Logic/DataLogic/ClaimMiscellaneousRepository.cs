using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class ClaimMiscellaneousRepository : EntityRepository<ClaimMiscellaneousEntity>
    {
        public List<ClaimMiscellaneousEntity> GetByClaim(int claimId)
        {
            return Context.Find<ClaimMiscellaneousEntity>()
                          .Where(x => x.ClaimId == claimId && x.IsActive == true)
                          .List();
        }
    }
}