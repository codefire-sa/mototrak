using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class ClaimLabourRepository : EntityRepository<ClaimLabourEntity>
    {
        public List<ClaimLabourEntity> GetByClaim(int claimId)
        {
            return Context.Find<ClaimLabourEntity>()
                          .Where(x => x.ClaimId == claimId && x.IsActive == true)
                          .List();
        }
    }
}