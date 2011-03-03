using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class ClaimPartMap : EntityMapOverride<ClaimPartEntity>
    {
        protected override void OnOverride(EntityConfigurator<ClaimPartEntity> configurator)
        {
            configurator.Property(x => x.Part.Id);
            configurator.Property(x => x.PartType.Id);

            configurator.Join("dbo.Parts", x =>
                {
                    x.On("PartId", "Id");
                    x.Property(y => y.Part.Code);
                    x.Property(y => y.Part.Name);
                });

            configurator.Join("dbo.PartTypes", x =>
                {
                    x.On("PartTypeId", "Id");
                    x.Property(y => y.PartType.Code);
                    x.Property(y => y.PartType.Name);
                });
        }
    }
}