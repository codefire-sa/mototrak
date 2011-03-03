using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class CustomerMap : EntityMapOverride<CustomerEntity>
    {
        protected override void  OnOverride(EntityConfigurator<CustomerEntity> configurator)
        {
            configurator.Property(x => x.Language.Id);
            configurator.Property(x => x.Gender.Id);
            configurator.Property(x => x.PostalAddress.Line1).Column("PostalAddress1");
            configurator.Property(x => x.PostalAddress.Line2).Column("PostalAddress2");
            configurator.Property(x => x.PostalAddress.Line3).Column("PostalAddress3");
            configurator.Property(x => x.PostalAddress.Line4).Column("PostalAddress4");
            configurator.Property(x => x.PostalAddress.PostCode).Column("PostalAddressCode");
            configurator.Property(x => x.PhysicalAddress.Line1).Column("PhysicalAddress1");
            configurator.Property(x => x.PhysicalAddress.Line2).Column("PhysicalAddress2");
            configurator.Property(x => x.PhysicalAddress.Line3).Column("PhysicalAddress3");
            configurator.Property(x => x.PhysicalAddress.Line4).Column("PhysicalAddress4");
            configurator.Property(x => x.PhysicalAddress.PostCode).Column("PhysicalAddressCode"); 

            configurator.Join("dbo.Languages", x =>
                {
                    x.On("LanguageId", "Id");
                    x.Property(y => y.Language.Code);
                    x.Property(y => y.Language.Name);
                });

            configurator.Join("dbo.Genders", x =>
                {
                    x.On("GenderId", "Id");
                    x.Property(y => y.Gender.Code);
                    x.Property(y => y.Gender.Name);
                });
        }
    }
}