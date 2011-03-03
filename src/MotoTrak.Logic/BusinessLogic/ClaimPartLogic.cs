using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class ClaimPartLogic : BaseLogic
    {
        public ClaimPartLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public ClaimPartEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimParts.GetById(id);
            }
        }

        public List<ClaimPartEntity> GetByClaim(int claimId)
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimParts.GetByClaim(claimId);
            }
        }

        public void Save(ClaimPartEntity obj)
        {
            using (var db = CreateCatalog())
            {
                decimal discountPercent = 0;
                decimal partAmount = GetPartPrice(obj.ClaimId, obj.Part.Id, obj.PartType.Code, obj.PurchaseDate, out discountPercent);

                obj.DiscountPercent = discountPercent;
                obj.UnitAmount = partAmount;
                obj.ItemAmount = Math.Round(partAmount * obj.Quantity, 2);

                db.ClaimParts.Save(obj);
            }
        }

        private decimal GetPartPrice(int claimId, int partId, string partType, DateTime? effectiveDate, out decimal discountPercent)
        {
            using (var db = CreateCatalog())
            {
                decimal partAmount = 0;
                discountPercent = 0;

                if (effectiveDate == null) effectiveDate = DateTime.Today;
                var priceObj = db.PartPrices.GetPrice(partId, effectiveDate.Value);
                if (priceObj == null) return 0;

                var discountObj = db.PartDiscounts.GetById(priceObj.PartDiscount.Id);
                if (discountObj != null)
                {
                    var claimObj = db.Claims.GetById(claimId);
                    switch (claimObj.ClaimClass.Code)
                    {
                        case "W":
                            switch (partType)
                            {
                                case "S":
                                    discountPercent = discountObj.StockPercent;
                                    break;
                                case "E":
                                    discountPercent = discountObj.EmergencyPercent;
                                    break;
                            }
                            break;
                        case "M":
                            discountPercent = discountObj.ServicePercent;
                            break;
                    }
                }

                decimal discountAmount = Math.Round(priceObj.PartAmount * discountPercent / 100, 2);
                partAmount = priceObj.PartAmount - discountAmount;

                return partAmount;
            }
        }
    }
}