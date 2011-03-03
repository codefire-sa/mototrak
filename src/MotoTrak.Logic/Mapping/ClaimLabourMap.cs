using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class ClaimLabourMap : EntityMapOverride<ClaimLabourEntity>
    {
        protected override void OnOverride(EntityConfigurator<ClaimLabourEntity> configurator)
        {
            configurator.Property(x => x.Labour.Id);
            configurator.Table("dbo.ClaimLabour");

            configurator.Join("dbo.Labour", x =>
                {
                    x.On("LabourId", "Id");
                    x.Property(y => y.Labour.Code);
                    x.Property(y => y.Labour.Name);
                });
        }
    }
}