using System;
using System.Web.Mvc;
using Codefire.Utilities;
using MotoTrak.BusinessLogic;
using MotoTrak.Entities;
using MotoTrak.Models;

namespace MotoTrak.Web.Areas.Claim.Controllers
{
    public class WarrantyClaimController : ApplicationController
    {
        [Authorize]
        [Host("Warranty Claim")]
        public ActionResult Display(int id)
        {
            var claimSvc = new WarrantyClaimLogic(Ticket);
            ViewData.Model = claimSvc.GetById(id, true);

            return View();
        }

        #region [ Create ]

        [Authorize]
        [Host("New Warranty Claim")]
        public ActionResult Create(int id)
        {
            var claimObj = new ClaimEntity();
            claimObj.VehicleId = id;

            ViewData.Model = claimObj;
            ViewData["programId"] = BuildProgramList(claimObj.Program.Id);
            ViewData["claimTypeId"] = BuildClaimTypeList(claimObj.ClaimType.Id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("New Warranty Claim")]
        public ActionResult Create(int id, FormCollection form)
        {
            var claimObj = new ClaimEntity();
            claimObj.VehicleId = id;
            claimObj.JobCardNumber = form["jobCardNumber"];
            claimObj.InvoiceNumber = form["invoiceNumber"];
            claimObj.ExternalNumber = form["externalNumber"];
            claimObj.DiagnosticNumber = form["diagnosticNumber"];
            claimObj.RepairDate = StringUtility.ToDateTime(form["repairDate"]);
            claimObj.ClaimDistance = StringUtility.ToInt(form["claimDistance"]);
            claimObj.Program.Id = StringUtility.ToInt(form["programId"]);
            claimObj.ClaimType.Id = StringUtility.ToInt(form["claimTypeId"]);
            claimObj.FaultNote = form["faultNote"];
            claimObj.CauseNote = form["causeNote"];
            claimObj.RemedyNote = form["remedyNote"];

            ViewData.Model = claimObj;
            ViewData["programId"] = BuildProgramList(claimObj.Program.Id);
            ViewData["claimTypeId"] = BuildClaimTypeList(claimObj.ClaimType.Id);

            return View();
        }

        #endregion

        #region [ Edit ]

        [Authorize]
        [Host("Edit Warranty Claim")]
        public ActionResult Edit(int id)
        {
            var claimSvc = new ClaimLogic(Ticket);

            var claimObj = claimSvc.GetById(id);

            ViewData.Model = claimObj;
            ViewData["programId"] = BuildProgramList(claimObj.Program.Id);
            ViewData["claimTypeId"] = BuildClaimTypeList(claimObj.ClaimType.Id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Edit Warranty Claim")]
        public ActionResult Edit(int id, FormCollection form)
        {
            var claimSvc = new ClaimLogic(Ticket);
            var concernSvc = new CustomerConcernLogic(Ticket);
            var conditionSvc = new ConditionLogic(Ticket);

            int concernId = StringUtility.ToInt(form["customerConcernId"]);
            var concernObj = concernSvc.GetById(concernId);
            int conditionId = StringUtility.ToInt(form["conditionId"]);
            var conditionObj = conditionSvc.GetById(conditionId);

            var claimObj = claimSvc.GetById(id);

            claimObj.JobCardNumber = form["jobCardNumber"];
            claimObj.InvoiceNumber = form["invoiceNumber"];
            claimObj.ExternalNumber = form["externalNumber"];
            claimObj.DiagnosticNumber = form["diagnosticNumber"];
            claimObj.RepairDate = StringUtility.ToDateTime(form["repairDate"]);
            claimObj.ClaimDistance = StringUtility.ToInt(form["claimDistance"]);
            claimObj.Program.Id = StringUtility.ToInt(form["programId"]);
            claimObj.ClaimType.Id = StringUtility.ToInt(form["claimTypeId"]);
            if (concernObj != null)
            {
                claimObj.CustomerConcern.Id = concernObj.Id;
                claimObj.CustomerConcern.Code = concernObj.Code;
                claimObj.CustomerConcern.Name = concernObj.Name;
            }
            if (conditionObj != null)
            {
                claimObj.Condition.Id = conditionObj.Id;
                claimObj.Condition.Code = conditionObj.Code;
                claimObj.Condition.Name = conditionObj.Name;
            }
            claimObj.FaultNote = form["faultNote"];
            claimObj.CauseNote = form["causeNote"];
            claimObj.RemedyNote = form["remedyNote"];

            ViewData.Model = claimObj;
            ViewData["programId"] = BuildProgramList(claimObj.Program.Id);
            ViewData["claimTypeId"] = BuildClaimTypeList(claimObj.ClaimType.Id);

            claimSvc.Save(claimObj);

            return RedirectToAction("Display", "WarrantyClaim", new { id = claimObj.Id });
        }

        #endregion

        #region [ Submit ]

        [Authorize]
        [Host("Warranty Claim : Submit")]
        public ActionResult Submit(int id)
        {
            var model = new ClaimWorkflowModel();
            model.Id = id;

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Host("Warranty Claim : Submit")]
        public ActionResult Submit(int id, FormCollection form)
        {
            var model = new ClaimWorkflowModel();
            model.Id = id;
            model.Comment = form["comment"];

            var claimSvc = new WarrantyClaimLogic(Ticket);
            claimSvc.Submit(model);

            return RedirectToAction("Display", new { id = id });
        }

        #endregion

        [Authorize]
        [Host("Warranty Claim : Approve")]
        public ActionResult Approve(int id)
        {
            return View();
        }

        #region [ Reject ]

        [Authorize]
        [Host("Warranty Claim : Reject")]
        public ActionResult Reject(int id)
        {
            var model = new WarrantyClaimRejectModel();
            model.Id = id;

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Host("Warranty Claim : Reject")]
        public ActionResult Reject(int id, FormCollection form)
        {
            var model = new WarrantyClaimRejectModel();
            model.Id = id;
            model.RejectionReason.Id = StringUtility.ToInt(form["rejectionReasonId"]);
            model.Comment = form["comment"];

            var claimSvc = new WarrantyClaimLogic(Ticket);
            claimSvc.Reject(model);

            return RedirectToAction("Display", new { id = id });
        } 
        
        #endregion

        #region [ Invoice ]

        [Authorize]
        [Host("Warranty Claim : Invoice")]
        public ActionResult Invoice(int id)
        {
            var model = new WarrantyClaimInvoiceModel();
            model.Id = id;

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Host("Warranty Claim : Invoice")]
        public ActionResult Invoice(int id, FormCollection form)
        {
            var model = new WarrantyClaimInvoiceModel();
            model.Id = id;
            model.InvoiceNumber = form["invoiceNumber"];
            model.RepairDate = StringUtility.ToDateTime(form["repairDate"]);
            model.Comment = form["comment"];

            var claimSvc = new WarrantyClaimLogic(Ticket);
            claimSvc.Invoice(model);

            return RedirectToAction("Display", new { id = id });
        }

        #endregion

        [Authorize]
        [Host("Warranty Claim : Transfer")]
        public ActionResult Transfer(int id)
        {
            return View();
        }

        #region [ Return to Dealer ]

        [Authorize]
        [Host("Warranty Claim : Return to Dealer")]
        public ActionResult Return(int id)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Warranty Claim : Return to Dealer")]
        public ActionResult Return(int id, FormCollection form)
        {
            var model = new ClaimWorkflowModel();
            model.Id = id;
            model.Comment = form["comment"];

            var claimSvc = new WarrantyClaimLogic(Ticket);
            claimSvc.Return(model);

            return RedirectToAction("Display", new { id = id });
        }

        #endregion

        #region [ Cancel ]

        [Authorize]
        [Host("Warranty Claim : Cancel")]
        public ActionResult Cancel(int id)
        {
            var model = new ClaimWorkflowModel();
            model.Id = id;

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Host("Warranty Claim : Cancel")]
        public ActionResult Cancel(int id, FormCollection form)
        {
            var model = new ClaimWorkflowModel();
            model.Id = id;
            model.Comment = form["comment"];

            var claimSvc = new WarrantyClaimLogic(Ticket);
            claimSvc.Cancel(model);

            return RedirectToAction("Display", new { id = id });
        }

        #endregion


        private SelectList BuildProgramList(int programId)
        {
            var programSvc = new ProgramLogic(Ticket);
            var programList = programSvc.GetAll();

            return new SelectList(programList, "Id", "Name", programId);
        }

        private SelectList BuildClaimTypeList(int claimTypeId)
        {
            var claimTypeSvc = new ClaimTypeLogic(Ticket);
            var claimTypeList = claimTypeSvc.GetAll();

            return new SelectList(claimTypeList, "Id", "Name", claimTypeId);
        }
    }
}