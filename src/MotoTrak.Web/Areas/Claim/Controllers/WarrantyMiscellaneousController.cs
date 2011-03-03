using System;
using System.Web.Mvc;
using MotoTrak.Entities;
using MotoTrak.BusinessLogic;
using Codefire.Utilities;

namespace MotoTrak.Web.Areas.Claim.Controllers
{
    public class WarrantyMiscellaneousController : ApplicationController
    {
        [Authorize]
        [Host("Add Miscellaneous")]
        public ActionResult Create(int id)
        {
            var obj = new ClaimMiscellaneousEntity();
            obj.ClaimId = id;

            ViewData.Model = obj;

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Add Miscellaneous")]
        public ActionResult Create(int id, FormCollection form)
        {
            var claimMiscellaneousSvc = new ClaimMiscellaneousLogic(Ticket);
            var miscellaneousSvc = new MiscellaneousLogic(Ticket);

            var miscellaneousId = StringUtility.ToInt(form["miscellaneousId"]);
            var miscellaneousObj = miscellaneousSvc.GetById(miscellaneousId);

            var obj = new ClaimMiscellaneousEntity();
            obj.ClaimId = id;
            if (miscellaneousObj != null)
            {
                obj.Miscellaneous.Id = miscellaneousObj.Id;
                obj.Miscellaneous.Code = miscellaneousObj.Code;
                obj.Miscellaneous.Name = miscellaneousObj.Name;
            }
            obj.SupplierName = form["supplierName"];
            obj.InvoiceNumber = form["invoiceNumber"];
            obj.ItemAmount = StringUtility.ToDecimal(form["itemAmount"]);

            claimMiscellaneousSvc.Save(obj);

            return RedirectToAction("Display", "WarrantyClaim", new { id = obj.ClaimId });
        }

        [Authorize]
        [Host("Edit Miscellaneous")]
        public ActionResult Edit(int id)
        {
            var claimMiscellaneousSvc = new ClaimMiscellaneousLogic(Ticket);
            var obj = claimMiscellaneousSvc.GetById(id);

            ViewData.Model = obj;

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Edit Miscellaneous")]
        public ActionResult Edit(int id, FormCollection form)
        {
            var claimMiscellaneousSvc = new ClaimMiscellaneousLogic(Ticket);
            var miscellaneousSvc = new MiscellaneousLogic(Ticket);

            var miscellaneousId = StringUtility.ToInt(form["miscellaneousId"]);
            var miscellaneousObj = miscellaneousSvc.GetById(miscellaneousId);

            var obj = claimMiscellaneousSvc.GetById(id);
            if (miscellaneousObj != null)
            {
                obj.Miscellaneous.Id = miscellaneousObj.Id;
                obj.Miscellaneous.Code = miscellaneousObj.Code;
                obj.Miscellaneous.Name = miscellaneousObj.Name;
            }
            obj.SupplierName = form["supplierName"];
            obj.InvoiceNumber = form["invoiceNumber"];
            obj.ItemAmount = StringUtility.ToDecimal(form["itemAmount"]);

            claimMiscellaneousSvc.Save(obj);

            return RedirectToAction("Display", "WarrantyClaim", new { id = obj.ClaimId });
        }
    }
}