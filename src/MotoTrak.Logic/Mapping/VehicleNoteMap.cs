using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class VehicleNoteMap : EntityMapOverride<VehicleNoteEntity>
    {
        protected override void OnOverride(EntityConfigurator<VehicleNoteEntity> configurator)
        {
            configurator.Ignore(x => x.ClaimCode);
            configurator.Ignore(x => x.UserCode);

            configurator.Join("dbo.Claims", x =>
                {
                    x.On("ClaimId", "Id");
                    x.Property(y => y.ClaimCode);
                });

            configurator.Join("dbo.Users", x =>
                {
                    x.On("CreateUserId", "Id");
                    x.Property(y => y.UserCode);
                });
        }
    }
}