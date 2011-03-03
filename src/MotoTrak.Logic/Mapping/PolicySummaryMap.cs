using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class PolicySummaryMap : EntityMapOverride<PolicySummaryEntity>
    {
        protected override void OnOverride(EntityConfigurator<PolicySummaryEntity> configurator)
        {
            configurator.Property(x => x.Code).Column("PolicyCode");
            configurator.Property(x => x.Product.Id);
            configurator.Property(x => x.Product.Code);
            configurator.Property(x => x.Product.Name);
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
            configurator.View("dbo.v_PolicySummary");
            configurator.ReadOnly();
        }
    }
}