using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class VehicleServiceMap : EntityMapOverride<VehicleServiceEntity>
    {
        protected override void OnOverride(EntityConfigurator<VehicleServiceEntity> configurator)
        {
            configurator.Property(x => x.Dealer.Id);

            configurator.Join("dbo.Dealers", x =>
                {
                    x.On("DealerId", "Id");
                    x.Property(y => y.Dealer.Code);
                    x.Property(y => y.Dealer.Name);
                });
        }
    }
}