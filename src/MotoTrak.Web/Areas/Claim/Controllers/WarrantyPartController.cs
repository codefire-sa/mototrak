using System;
using System.Web.Mvc;
using MotoTrak.Entities;
using MotoTrak.BusinessLogic;
using Codefire.Extensions;
using Codefire.Utilities;

namespace MotoTrak.Web.Areas.Claim.Controllers
{
    public class WarrantyPartController : ApplicationController
    {
        [Authorize]
        [Host("Add Part")]
        public ActionResult Create(int id)
        {
            var obj = new ClaimPartEntity();
            obj.ClaimId = id;

            ViewData.Model = obj;
            ViewData["partTypeId"] = BuildPartTypeList(obj.PartType.Id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Add Part")]
        public ActionResult Create(int id, FormCollection form)
        {
            var claimPartSvc = new ClaimPartLogic(Ticket);
            var partSvc = new PartLogic(Ticket);
            var partTypeSvc = new PartTypeLogic(Ticket);

            var partId = StringUtility.ToInt(form["partId"]);
            var partTypeId = StringUtility.ToInt(form["partTypeId"]);

            var partObj = partSvc.GetById(partId);
            var partTypeObj = partTypeSvc.GetById(partTypeId);

            var obj = new ClaimPartEntity();
            obj.ClaimId = id;
            if (partObj != null)
            {
                obj.Part.Id = partObj.Id;
                obj.Part.Code = partObj.Code;
                obj.Part.Name = partObj.Name;
            }
            if (partTypeObj != null)
            {
                obj.PartType.Id = partTypeObj.Id;
                obj.PartType.Code = partTypeObj.Code;
                obj.PartType.Name = partTypeObj.Name;
            }
            obj.ReferenceNumber = form["referenceNumber"];
            obj.PurchaseDate = StringUtility.ToDateTime(form["purchaseDate"]);
            obj.Quantity = StringUtility.ToDecimal(form["quantity"]);

            claimPartSvc.Save(obj);

            return RedirectToAction("Display", "WarrantyClaim", new { id = obj.ClaimId });
        }

        [Authorize]
        [Host("Edit Part")]
        public ActionResult Edit(int id)
        {
            var claimPartSvc = new ClaimPartLogic(Ticket);
            var obj = claimPartSvc.GetById(id);

            ViewData.Model = obj;
            ViewData["partTypeId"] = BuildPartTypeList(obj.PartType.Id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Edit Part")]
        public ActionResult Edit(int id, FormCollection form)
        {
            var claimPartSvc = new ClaimPartLogic(Ticket);
            var partSvc = new PartLogic(Ticket);
            var partTypeSvc = new PartTypeLogic(Ticket);

            var partId = StringUtility.ToInt(form["partId"]);
            var partTypeId = StringUtility.ToInt(form["partTypeId"]);

            var partObj = partSvc.GetById(partId);
            var partTypeObj = partTypeSvc.GetById(partTypeId);

            var obj = claimPartSvc.GetById(id);
            if (partObj != null)
            {
                obj.Part.Id = partObj.Id;
                obj.Part.Code = partObj.Code;
                obj.Part.Name = partObj.Name;
            }
            if (partTypeObj != null)
            {
                obj.PartType.Id = partTypeObj.Id;
                obj.PartType.Code = partTypeObj.Code;
                obj.PartType.Name = partTypeObj.Name;
            }
            obj.ReferenceNumber = form["referenceNumber"];
            obj.PurchaseDate = StringUtility.ToDateTime(form["purchaseDate"]);
            obj.Quantity = StringUtility.ToDecimal(form["quantity"]);

            claimPartSvc.Save(obj);

            return RedirectToAction("Display", "WarrantyClaim", new { id = obj.ClaimId });
        }

        private SelectList BuildPartTypeList(int partTypeId)
        {
            var partTypeSvc = new PartTypeLogic(Ticket);
            var partTypeList = partTypeSvc.GetAll();

            return new SelectList(partTypeList, "Id", "Name", partTypeId);
        }
    }
}