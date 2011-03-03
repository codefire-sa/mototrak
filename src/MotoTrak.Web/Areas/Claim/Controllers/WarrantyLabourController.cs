using System;
using System.Web.Mvc;
using MotoTrak.BusinessLogic;
using MotoTrak.Entities;
using Codefire.Utilities;

namespace MotoTrak.Web.Areas.Claim.Controllers
{
    public class WarrantyLabourController : ApplicationController
    {
        [Authorize]
        [Host("Add Labour")]
        public ActionResult Create(int id)
        {
            var obj = new ClaimLabourEntity();
            obj.ClaimId = id;

            ViewData.Model = obj;

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Add Labour")]
        public ActionResult Create(int id, FormCollection form)
        {
            var labourSvc = new LabourLogic(Ticket);

            var labourId = StringUtility.ToInt(form["labourId"]);
            var labourObj = labourSvc.GetById(labourId);

            var obj = new ClaimLabourEntity();
            obj.ClaimId = id;
            if (labourObj != null)
            {
                obj.Labour.Id = labourObj.Id;
                obj.Labour.Code = labourObj.Code;
                obj.Labour.Name = labourObj.Name;
            }
            obj.Hours = decimal.Parse(form["hours"]);

            ViewData.Model = obj;

            return View();
        }

        [Authorize]
        [Host("Edit Labour")]
        public ActionResult Edit(int id)
        {
            var claimLabourSvc = new ClaimLabourLogic(Ticket);
            var obj = claimLabourSvc.GetById(id);

            ViewData.Model = obj;

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Edit Labour")]
        public ActionResult Edit(int id, FormCollection form)
        {
            var labourSvc = new LabourLogic(Ticket);
            var claimLabourSvc = new ClaimLabourLogic(Ticket);

            var labourId = StringUtility.ToInt(form["labourId"]);
            var labourObj = labourSvc.GetById(labourId);

            var obj = claimLabourSvc.GetById(id);
            if (labourObj != null)
            {
                obj.Labour.Id = labourObj.Id;
                obj.Labour.Code = labourObj.Code;
                obj.Labour.Name = labourObj.Name;
            }
            obj.Hours = StringUtility.ToDecimal(form["hours"]);

            claimLabourSvc.Save(obj);

            return RedirectToAction("Display", "WarrantyClaim", new { id = obj.ClaimId });
        }
    }
}