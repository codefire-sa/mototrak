using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class ClaimPartRepository : EntityRepository<ClaimPartEntity>
    {
        public List<ClaimPartEntity> GetByClaim(int claimId)
        {
            return Context.Find<ClaimPartEntity>()
                          .Where(x => x.ClaimId == claimId && x.IsActive == true)
                          .List();
        }
    }
}