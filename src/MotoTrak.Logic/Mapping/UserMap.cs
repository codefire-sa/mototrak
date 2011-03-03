using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class UserMap : EntityMapOverride<UserEntity>
    {
        protected override void OnOverride(EntityConfigurator<UserEntity> configurator)
        {
            configurator.Property(x => x.Dealer.Id);

            configurator.Join("dbo.Dealers", x =>
                {
                    x.On("DealerId", "Id");
                    x.Property(y => y.Dealer.Code);
                    x.Property(y => y.Dealer.Name);
                });
        }
    }
}