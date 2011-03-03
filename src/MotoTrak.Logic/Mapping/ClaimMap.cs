using System;
using MotoTrak.Entities;
using Codefire.Storm.Mapping;

namespace MotoTrak.Mapping
{
    public class ClaimMap : EntityMapOverride<ClaimEntity>
    {
        protected override void OnOverride(EntityConfigurator<ClaimEntity> configurator)
        {
            configurator.Property(x => x.Dealer.Id);
            configurator.Property(x => x.Fault.Id);
            configurator.Property(x => x.CustomerConcern.Id);
            configurator.Property(x => x.Condition.Id);
            configurator.Property(x => x.RejectionReason.Id);
            configurator.Property(x => x.Program.Id);
            configurator.Property(x => x.ClaimType.Id);
            configurator.Property(x => x.ClaimStatus.Id);
            configurator.Property(x => x.ClaimClass.Id);

            configurator.Property(x => x.ClaimAmount.LabourAmount).Column("ClaimLabourAmount");
            configurator.Property(x => x.ClaimAmount.PartAmount).Column("ClaimPartAmount");
            configurator.Property(x => x.ClaimAmount.MiscellaneousAmount).Column("ClaimMiscellaneousAmount");
            configurator.Property(x => x.ClaimAmount.TaxAmount).Column("ClaimTaxAmount");
            configurator.Property(x => x.ClaimAmount.TotalAmount).Column("ClaimTotalAmount");

            configurator.Property(x => x.AuthorisedAmount.LabourAmount).Column("AuthorisedLabourAmount");
            configurator.Property(x => x.AuthorisedAmount.PartAmount).Column("AuthorisedPartAmount");
            configurator.Property(x => x.AuthorisedAmount.MiscellaneousAmount).Column("AuthorisedMiscellaneousAmount");
            configurator.Property(x => x.AuthorisedAmount.TaxAmount).Column("AuthorisedTaxAmount");
            configurator.Property(x => x.AuthorisedAmount.TotalAmount).Column("AuthorisedTotalAmount");

            configurator.Join("dbo.Dealers", x =>
                {
                    x.On("DealerId", "Id");
                    x.Property(y => y.Dealer.Code);
                    x.Property(y => y.Dealer.Name);
                });

            configurator.Join("dbo.Faults", x =>
                {
                    x.On("FaultId", "Id");
                    x.Property(y => y.Fault.Code);
                    x.Property(y => y.Fault.Name);
                });

            configurator.Join("dbo.CustomerConcerns", x =>
                {
                    x.On("CustomerConcernId", "Id");
                    x.Property(y => y.CustomerConcern.Code);
                    x.Property(y => y.CustomerConcern.Name);
                });

            configurator.Join("dbo.Conditions", x =>
                {
                    x.On("ConditionId", "Id");
                    x.Property(y => y.Condition.Code);
                    x.Property(y => y.Condition.Name);
                });

            configurator.Join("dbo.RejectionReasons", x =>
                {
                    x.On("RejectionReasonId", "Id");
                    x.Property(y => y.RejectionReason.Code);
                    x.Property(y => y.RejectionReason.Name);
                });

            configurator.Join("dbo.Programs", x =>
                {
                    x.On("ProgramId", "Id");
                    x.Property(y => y.Program.Code);
                    x.Property(y => y.Program.Name);
                });

            configurator.Join("dbo.ClaimTypes", x =>
                {
                    x.On("ClaimTypeId", "Id");
                    x.Property(y => y.ClaimType.Code);
                    x.Property(y => y.ClaimType.Name);
                });

            configurator.Join("dbo.ClaimStatuses", x =>
                {
                    x.On("ClaimStatusId", "Id");
                    x.Property(y => y.ClaimStatus.Code);
                    x.Property(y => y.ClaimStatus.Name);
                });

            configurator.Join("dbo.ClaimClasses", x =>
                {
                    x.On("ClaimClassId", "Id");
                    x.Property(y => y.ClaimClass.Code);
                    x.Property(y => y.ClaimClass.Name);
                });
        }
    }
}