using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class PartPriceMap : EntityMapOverride<PartPriceEntity>
    {
        protected override void OnOverride(EntityConfigurator<PartPriceEntity> configurator)
        {
            configurator.Property(x => x.PartDiscount.Id);

            configurator.Join("dbo.PartDiscounts", x =>
                {
                    x.On("PartDiscountId", "Id");
                    x.Property(y => y.PartDiscount.Code);
                    x.Property(y => y.PartDiscount.Name);
                });
        }
    }
}