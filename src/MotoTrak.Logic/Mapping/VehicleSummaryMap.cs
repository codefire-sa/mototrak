using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class VehicleSummaryMap : EntityMapOverride<VehicleSummaryEntity>
    {
        protected override void OnOverride(EntityConfigurator<VehicleSummaryEntity> configurator)
        {
            configurator.Property(x => x.Model.Id);
            configurator.Property(x => x.Model.Code);
            configurator.Property(x => x.Model.Name);
            configurator.Property(x => x.Dealer.Id);
            configurator.Property(x => x.Dealer.Code);
            configurator.Property(x => x.Dealer.Name);
            configurator.Property(x => x.Customer.Id);
            configurator.Property(x => x.Customer.Title).Column("Title");
            configurator.Property(x => x.Customer.Initials).Column("Initials");
            configurator.Property(x => x.Customer.LastName).Column("LastName");

            configurator.Table(null);
            configurator.View("dbo.v_VehicleSummary");
            configurator.ReadOnly();
        }
    }
}