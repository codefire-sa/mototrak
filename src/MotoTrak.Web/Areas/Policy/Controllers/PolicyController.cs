using System;
using System.Web.Mvc;
using MotoTrak.Entities;
using MotoTrak.BusinessLogic;
using Codefire.Extensions;
using Codefire.Utilities;

namespace MotoTrak.Web.Areas.Policy.Controllers
{
    public class PolicyController : ApplicationController
    {
        [Authorize]
        [Host("Policy")]
        public ActionResult Display(int id)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var policySvc = new PolicyLogic(Ticket);

            var policyObj = policySvc.GetById(id);
            var vehicleObj = vehicleSvc.GetById(policyObj.VehicleId);

            ViewData.Model = policyObj;
            ViewData["vehicle"] = vehicleObj;

            return View();
        }

        [Authorize]
        [Host("Create Policy")]
        public ActionResult Create(int id)
        {
            var policyObj = new PolicyEntity();
            policyObj.VehicleId = id;
            policyObj.StartDate = DateTime.Today;

            ViewData.Model = policyObj;
            ViewData["productId"] = BuildProductList(0);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Create Policy")]
        public ActionResult Create(int id, FormCollection form)
        {
            var policySvc = new PolicyLogic(Ticket);

            int productId = StringUtility.ToInt(form["productId"]);
            var startDate = StringUtility.ToDateTime(form["startDate"]);
            var startDistance = StringUtility.ToInt(form["startDistance"]);

            var policyObj = new PolicyEntity();
            policyObj.VehicleId = id;
            policyObj.StartDate = startDate.Value;
            policyObj.StartDistance = startDistance;
            policyObj.Product.Id = productId;
            policySvc.Create(policyObj);

            return RedirectToAction("Display", "Vehicle", new { id = id });
        }

        [Authorize]
        [Host("Edit Policy")]
        public ActionResult Edit(int id)
        {
            var policySvc = new PolicyLogic(Ticket);

            var policyObj = policySvc.GetById(id);

            ViewData.Model = policyObj;
            ViewData["productId"] = BuildProductList(policyObj.Product.Id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Edit Policy")]
        public ActionResult Edit(int id, FormCollection form)
        {
            var policySvc = new PolicyLogic(Ticket);
            var productSvc = new ProductLogic(Ticket);

            int productId = StringUtility.ToInt(form["productId"]);
            var startDate = StringUtility.ToDateTime(form["startDate"]);
            var startDistance = StringUtility.ToInt(form["startDistance"]);

            var policyObj = policySvc.GetById(id);
            policyObj.StartDate = startDate.Value;
            policyObj.StartDistance = startDistance;
            policyObj.Product.Id = productId;
            policySvc.Update(policyObj);

            return RedirectToAction("Display", "Vehicle", new { id = policyObj.VehicleId });
        }

        private SelectList BuildProductList(int productId)
        {
            var productSvc = new ProductLogic(Ticket);
            var productList = productSvc.GetAll();

            return new SelectList(productList, "Id", "Name", productId);
        }
    }
}