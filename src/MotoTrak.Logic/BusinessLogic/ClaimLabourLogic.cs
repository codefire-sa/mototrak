using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class ClaimLabourLogic : BaseLogic
    {
        public ClaimLabourLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public ClaimLabourEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimLabour.GetById(id);
            }
        }

        public List<ClaimLabourEntity> GetByClaim(int claimId)
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimLabour.GetByClaim(claimId);
            }
        }

        public void Save(ClaimLabourEntity obj)
        {
            using (var db = CreateCatalog())
            {
                var claimObj = db.Claims.GetById(obj.ClaimId);

                obj.ItemAmount = Math.Round(obj.Hours * claimObj.LabourRateAmount, 2);
                db.ClaimLabour.Save(obj);
            }
        }
    }
}