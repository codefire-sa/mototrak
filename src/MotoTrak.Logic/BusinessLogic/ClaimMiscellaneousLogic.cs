using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class ClaimMiscellaneousLogic : BaseLogic
    {
        public ClaimMiscellaneousLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public ClaimMiscellaneousEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimMiscellaneous.GetById(id);
            }
        }

        public List<ClaimMiscellaneousEntity> GetByClaim(int claimId)
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimMiscellaneous.GetByClaim(claimId);
            }
        }

        public void Save(ClaimMiscellaneousEntity obj)
        {
            using (var db = CreateCatalog())
            {
                db.ClaimMiscellaneous.Save(obj);
            }
        }
    }
}