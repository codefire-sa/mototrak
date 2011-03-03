using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class ClaimHistoryMap : EntityMapOverride<ClaimHistoryEntity>
    {
        protected override void OnOverride(EntityConfigurator<ClaimHistoryEntity> configurator)
        {
            configurator.Property(x => x.ClaimStatus.Id);
            configurator.Ignore(x => x.UserCode);
            configurator.Table("dbo.ClaimHistory");

            configurator.Join("dbo.ClaimStatuses", x =>
                {
                    x.On("ClaimStatusId", "Id");
                    x.Property(y => y.ClaimStatus.Code);
                    x.Property(y => y.ClaimStatus.Name);
                });

            configurator.Join("dbo.Users", x =>
                {
                    x.On("CreateUserId", "Id");
                    x.Property(y => y.UserCode);
                });
        }
    }
}