using System;
using System.Web.Mvc;
using MotoTrak.Entities;
using MotoTrak.BusinessLogic;
using Codefire.Extensions;
using Codefire.Utilities;

namespace MotoTrak.Web.Areas.Policy.Controllers
{
    public class VehicleServiceController : ApplicationController
    {
        [Authorize]
        [Host("Vehicle Services")]
        public ActionResult Search()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Vehicle Services")]
        public ActionResult Search(VehicleSearchRequest request)
        {
            ViewData["resultArea"] = "Policy";
            ViewData["resultController"] = "VehicleService";
            ViewData["resultAction"] = "List";

            ViewData["vinNumber"] = request.VinNumber;
            ViewData["chassisNumber"] = request.ChassisNumber;
            ViewData["engineNumber"] = request.EngineNumber;
            ViewData["registrationNumber"] = request.RegistrationNumber;
            ViewData["initials"] = request.Initials;
            ViewData["lastName"] = request.LastName;
            ViewData["limit"] = request.Limit;

            var vehicleSvc = new VehicleLogic(Ticket);
            var results = vehicleSvc.Search(request);

            if (results.Rows.Count == 1)
            {
                int vehicleId = results.Rows[0].Get<int>("Id");
                return RedirectToAction("List", new { id = vehicleId });
            }

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Rows.Count);

            return View();
        }

        [Authorize]
        [Host("Vehicle Services")]
        public ActionResult List(int id)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var vehicleServiceSvc = new VehicleServiceLogic(Ticket);

            ViewData.Model = vehicleServiceSvc.GetByVehicle(id);
            ViewData["vehicle"] = vehicleSvc.GetById(id);
            ViewData["deleteId"] = TempData["vehicleService_deleteId"] ?? 0;

            return View();
        }

        [Authorize]
        [Host("Vehicle Services")]
        public ActionResult Create(int id)
        {
            var vehicleObj = new VehicleServiceEntity();
            vehicleObj.VehicleId = id;

            ViewData.Model = vehicleObj;

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Vehicle Services")]
        public ActionResult Create(int id, FormCollection form)
        {
            var vehicleServiceSvc = new VehicleServiceLogic(Ticket);
            var dealerSvc = new DealerLogic(Ticket);

            var dealerId = StringUtility.ToInt(form["dealerId"]);
            var dealerObj = dealerSvc.GetById(dealerId);

            var serviceObj = new VehicleServiceEntity();
            serviceObj.VehicleId = id;
            if (dealerObj != null)
            {
                serviceObj.Dealer.Id = dealerObj.Id;
                serviceObj.Dealer.Code = dealerObj.Code;
                serviceObj.Dealer.Name = dealerObj.Name;
            }
            serviceObj.ServiceDate = StringUtility.ToDateTime(form["serviceDate"]);
            serviceObj.ServiceDistance = int.Parse(form["serviceDistance"]);
            serviceObj.InvoiceNumber = form["invoiceNumber"];

            vehicleServiceSvc.Save(serviceObj);

            DisplayInformation(string.Format("Vehicle service ({0}) has been successfully created.", serviceObj.ServiceDistance));

            var addMore = (form["addMore"] == "on");
            if (addMore)
            {
                return RedirectToAction("Create", new { id = id });
            }
            else
            {
                return RedirectToAction("List", new { id = id });
            }
        }

        [Authorize]
        [Host("Vehicle Services")]
        public ActionResult Edit(int id)
        {
            var vehicleServiceSvc = new VehicleServiceLogic(Ticket);
            ViewData.Model = vehicleServiceSvc.GetById(id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Vehicle Services")]
        public ActionResult Edit(int id, FormCollection form)
        {
            var vehicleServiceSvc = new VehicleServiceLogic(Ticket);
            var dealerSvc = new DealerLogic(Ticket);

            var dealerId = StringUtility.ToInt(form["dealerId"]);
            var dealerObj = dealerSvc.GetById(dealerId);

            var serviceObj = vehicleServiceSvc.GetById(id);
            if (dealerObj != null)
            {
                serviceObj.Dealer.Id = dealerObj.Id;
                serviceObj.Dealer.Code = dealerObj.Code;
                serviceObj.Dealer.Name = dealerObj.Name;
            }
            serviceObj.ServiceDate = StringUtility.ToDateTime(form["serviceDate"]);
            serviceObj.ServiceDistance = int.Parse(form["serviceDistance"]);
            serviceObj.InvoiceNumber = form["invoiceNumber"];

            vehicleServiceSvc.Save(serviceObj);

            DisplayInformation(string.Format("Vehicle service ({0}) has been successfully updated.", serviceObj.ServiceDistance));

            return RedirectToAction("List", new { id = serviceObj.VehicleId });
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var vehicleServiceSvc = new VehicleServiceLogic(Ticket);

            var serviceObj = vehicleServiceSvc.GetById(id);
            vehicleServiceSvc.Delete(id);

            DisplayInformation(string.Format("Vehicle service ({0}) has been successfully deleted.", serviceObj.ServiceDistance));
            TempData["vehicleService_deleteId"] = id;

            return RedirectToAction("List", new { id = serviceObj.VehicleId });
        }

        [Authorize]
        public ActionResult Undo(int id)
        {
            var vehicleServiceSvc = new VehicleServiceLogic(Ticket);

            var serviceObj = vehicleServiceSvc.GetById(id);
            vehicleServiceSvc.Reinstate(id);

            DisplayInformation(string.Format("Vehicle service ({0}) has been successfully reinstated.", serviceObj.ServiceDistance));

            return RedirectToAction("List", new { id = serviceObj.VehicleId });
        }
    }
}