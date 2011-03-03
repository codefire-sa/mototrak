using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class VehicleMap : EntityMapOverride<VehicleEntity>
    {
        protected override void OnOverride(EntityConfigurator<VehicleEntity> configurator)
        {
            configurator.Property(x => x.Model.Id);
            configurator.Property(x => x.Dealer.Id);
            configurator.Property(x => x.CurrentDistanceUser.Id);
            configurator.Property(x => x.VehicleStatus.Id);

            configurator.Join("dbo.Models", x =>
                {
                    x.On("ModelId", "Id");
                    x.Property(y => y.Model.Code);
                    x.Property(y => y.Model.Name);
                });

            configurator.Join("dbo.Dealers", x =>
                {
                    x.On("DealerId", "Id");
                    x.Property(y => y.Dealer.Code);
                    x.Property(y => y.Dealer.Name);
                });

            configurator.Join("dbo.Users", x =>
                {
                    x.On("CurrentDistanceUserId", "Id");
                    x.Property(y => y.CurrentDistanceUser.Code).Column("UserCode");
                    x.Property(y => y.CurrentDistanceUser.Name).Column("UserName");
                });

            configurator.Join("dbo.VehicleStatuses", x =>
                {
                    x.On("VehicleStatusId", "Id");
                    x.Property(y => y.VehicleStatus.Code);
                    x.Property(y => y.VehicleStatus.Name);
                });
        }
    }
}