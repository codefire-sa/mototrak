using System;
using System.Data;
using MotoTrak.DataLogic;
using MotoTrak.Entities;
using MotoTrak.Models;
using Codefire.Storm;

namespace MotoTrak.BusinessLogic
{
    public class WarrantyClaimLogic : BaseLogic
    {
        public WarrantyClaimLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public WarrantyClaimModel GetById(int id, bool includeItems)
        {
            var claimMsg = new WarrantyClaimModel();

            using (var db = CreateCatalog())
            {
                var claimObj = db.Claims.GetById(id);
                if (claimObj != null)
                {
                    claimMsg.Claim = claimObj;
                    claimMsg.Policy = db.Policies.GetSummary(claimObj.PolicyId);

                    if (includeItems)
                    {
                        claimMsg.Labour = db.ClaimLabour.GetByClaim(id);
                        claimMsg.Parts = db.ClaimParts.GetByClaim(id);
                        claimMsg.Miscellaneous = db.ClaimMiscellaneous.GetByClaim(id);
                        claimMsg.Attachments = db.Attachments.GetByClaim(id);
                    }
                }
            }

            return claimMsg;
        }

        public void Submit(ClaimWorkflowModel model)
        {
            using (var db = CreateCatalog())
            {
                var claimObj = db.Claims.GetById(model.Id);
                var statusObj = db.ClaimStatuses.GetByCode("SUBM");

                claimObj.SubmitDate = DateTime.Now;
                claimObj.ClaimStatus.Id = statusObj.Id;
                db.Claims.Update(claimObj);

                db.ClaimHistory.Create(claimObj.Id, statusObj.Id);

                if (!string.IsNullOrWhiteSpace(model.Comment))
                {
                    var vehicleSvc = new VehicleLogic(Ticket);
                    vehicleSvc.AddNote(claimObj.PolicyId, claimObj.Id, model.Comment);
                }
            }
        }

        public void Reject(WarrantyClaimRejectModel model)
        {
            using (var db = CreateCatalog())
            {
                var claimObj = db.Claims.GetById(model.Id);
                var statusObj = db.ClaimStatuses.GetByCode("REJ");

                claimObj.RejectionReason.Id = model.RejectionReason.Id;
                claimObj.ClaimStatus.Id = statusObj.Id;
                db.Claims.Update(claimObj);

                db.ClaimHistory.Create(claimObj.Id, statusObj.Id);

                if (!string.IsNullOrWhiteSpace(model.Comment))
                {
                    var vehicleSvc = new VehicleLogic(Ticket);
                    vehicleSvc.AddNote(claimObj.PolicyId, claimObj.Id, model.Comment);
                }
            }
        }

        public void Invoice(WarrantyClaimInvoiceModel model)
        {
            using (var db = CreateCatalog())
            {
                var claimObj = db.Claims.GetById(model.Id);
                var statusObj = db.ClaimStatuses.GetByCode("INV");

                claimObj.InvoiceNumber = model.InvoiceNumber;
                claimObj.RepairDate = model.RepairDate;
                claimObj.ClaimStatus.Id = statusObj.Id;
                db.Claims.Update(claimObj);

                db.ClaimHistory.Create(claimObj.Id, statusObj.Id);

                if (!string.IsNullOrWhiteSpace(model.Comment))
                {
                    var vehicleSvc = new VehicleLogic(Ticket);
                    vehicleSvc.AddNote(claimObj.PolicyId, claimObj.Id, model.Comment);
                }
            }
        }

        public void Return(ClaimWorkflowModel model)
        {
            using (var db = CreateCatalog())
            {
                var claimObj = db.Claims.GetById(model.Id);
                var statusObj = db.ClaimStatuses.GetByCode("RET");

                claimObj.ClaimStatus.Id = statusObj.Id;
                db.Claims.Update(claimObj);

                db.ClaimHistory.Create(claimObj.Id, statusObj.Id);

                if (!string.IsNullOrWhiteSpace(model.Comment))
                {
                    var vehicleSvc = new VehicleLogic(Ticket);
                    vehicleSvc.AddNote(claimObj.PolicyId, claimObj.Id, model.Comment);
                }
            }
        }

        public void Cancel(ClaimWorkflowModel model)
        {
            using (var db = CreateCatalog())
            {
                var claimObj = db.Claims.GetById(model.Id);
                var statusObj = db.ClaimStatuses.GetByCode("CANC");

                claimObj.ClaimStatus.Id = statusObj.Id;
                db.Claims.Update(claimObj);

                db.ClaimHistory.Create(claimObj.Id, statusObj.Id);

                if (!string.IsNullOrWhiteSpace(model.Comment))
                {
                    var vehicleSvc = new VehicleLogic(Ticket);
                    vehicleSvc.AddNote(claimObj.PolicyId, claimObj.Id, model.Comment);
                }
            }
        }
    }
}