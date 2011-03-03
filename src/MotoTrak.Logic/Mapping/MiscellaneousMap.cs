using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class MiscellaneousMap : EntityMapOverride<MiscellaneousEntity>
    {
        protected override void OnOverride(EntityConfigurator<MiscellaneousEntity> configurator)
        {
            configurator.Table("dbo.Miscellaneous");
        }
    }
}