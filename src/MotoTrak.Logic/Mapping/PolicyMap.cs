using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;


namespace MotoTrak.Mapping
{
    public class PolicyMap : EntityMapOverride<PolicyEntity>
    {
        protected override void OnOverride(EntityConfigurator<PolicyEntity> configurator)
        {
            configurator.Property(x => x.Product.Id);
            configurator.Property(x => x.CancellationReason.Id);
            configurator.Property(x => x.CancelUser.Id);
            configurator.Property(x => x.PolicyStatus.Id);
            configurator.Property(x => x.PolicyClass.Id);

            configurator.Join("dbo.Products", x => 
                {
                    x.On("ProductId", "Id");
                    x.Property(y => y.Product.Code);
                    x.Property(y => y.Product.Name);
                });

            configurator.Join("dbo.PolicyStatuses", x =>
                {
                    x.On("PolicyStatusId", "Id");
                    x.Property(y => y.PolicyStatus.Code);
                    x.Property(y => y.PolicyStatus.Name);
                });

            configurator.Join("dbo.PolicyClasses", x =>
                {
                    x.On("PolicyClassId", "Id");
                    x.Property(y => y.PolicyClass.Code);
                    x.Property(y => y.PolicyClass.Name);
                });
        }
    }
}