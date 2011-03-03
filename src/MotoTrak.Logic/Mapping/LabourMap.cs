using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class LabourMap : EntityMapOverride<LabourEntity>
    {
        protected override void OnOverride(EntityConfigurator<LabourEntity> configurator)
        {
            configurator.Table("dbo.Labour");
        }
    }
}