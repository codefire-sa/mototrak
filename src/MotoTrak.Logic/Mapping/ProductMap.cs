using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class ProductMap : EntityMapOverride<ProductEntity>
    {
        protected override void OnOverride(EntityConfigurator<ProductEntity> configurator)
        {
            configurator.Property(x => x.PolicyClass.Id);

            configurator.Join("dbo.PolicyClasses", x =>
            {
                x.On("PolicyClassId", "Id");
                x.Property(y => y.PolicyClass.Code);
                x.Property(y => y.PolicyClass.Name);
            });
        }
    }
}