using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class ClaimMiscellaneousMap : EntityMapOverride<ClaimMiscellaneousEntity>
    {
        protected override void OnOverride(EntityConfigurator<ClaimMiscellaneousEntity> configurator)
        {
            configurator.Property(x => x.Miscellaneous.Id);
            configurator.Table("dbo.ClaimMiscellaneous");

            configurator.Join("dbo.Miscellaneous", x =>
                {
                    x.On("MiscellaneousId", "Id");
                    x.Property(y => y.Miscellaneous.Code);
                    x.Property(y => y.Miscellaneous.Name);
                });
        }
    }
}