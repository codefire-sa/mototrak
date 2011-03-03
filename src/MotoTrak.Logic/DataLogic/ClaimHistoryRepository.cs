using System;
using System.Collections.Generic;
using MotoTrak.Entities;
using Codefire.Storm;

namespace MotoTrak.DataLogic
{
    public class ClaimHistoryRepository : EntityRepository<ClaimHistoryEntity>
    {
        public List<ClaimHistoryEntity> GetByClaim(int claimId)
        {
            return Context.Find<ClaimHistoryEntity>()
                          .Where(x => x.ClaimId == claimId)
                          .List();
        }

        public int Create(int claimId, int claimStatusId)
        {
            var obj = new ClaimHistoryEntity();
            obj.ClaimId = claimId;
            obj.ClaimStatus.Id = claimStatusId;

            return Convert.ToInt32(Context.Insert(obj));
        }
    }
}