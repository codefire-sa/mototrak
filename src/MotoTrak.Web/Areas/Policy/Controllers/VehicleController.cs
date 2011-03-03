using System;
using System.Web.Mvc;
using MotoTrak.Entities;
using MotoTrak.Models;
using MotoTrak.BusinessLogic;
using Codefire.Extensions;
using Codefire.Utilities;

namespace MotoTrak.Web.Areas.Policy.Controllers
{
    public class VehicleController : ApplicationController
    {
        [Authorize]
        [Host("New Vehicle")]
        public ActionResult Create()
        {
            var vehicleObj = new VehicleEntity();
            ViewData.Model = vehicleObj;

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("New Vehicle")]
        public ActionResult Create(FormCollection form)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var modelSvc = new ModelLogic(Ticket);

            var modelId = StringUtility.ToInt(form["modelId"]);
            var modelObj = modelSvc.GetById(modelId);

            var vehicleObj = new VehicleEntity();
            vehicleObj.VinNumber = form["vinNumber"];
            vehicleObj.ChassisNumber = form["chassisNumber"];
            vehicleObj.EngineNumber = form["engineNumber"];
            vehicleObj.WholesaleDate = StringUtility.ToDateTime(form["wholesaleDate"]);
            if (modelObj != null)
            {
                vehicleObj.Model.Id = modelObj.Id;
                vehicleObj.Model.Code = modelObj.Code;
                vehicleObj.Model.Name = modelObj.Name;
            }
            vehicleObj.CurrentDistance = int.Parse(form["currentDistance"]);

            int id = vehicleSvc.Create(vehicleObj);

            return RedirectToAction("Display", new { id = id });
        }

        [Authorize]
        [Host("Add Customer")]
        public ActionResult CreateRetail(int id)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var vehicleMsg = vehicleSvc.GetModel(id, false);

            ViewData.Model = vehicleMsg;
            ViewData["languageId"] = BuildLanguageList(vehicleMsg.Customer.Language.Id);
            ViewData["genderId"] = BuildGenderList(vehicleMsg.Customer.Gender.Id);
            ViewData["vehicleStatusId"] = BuildVehicleStatusList(vehicleMsg.Vehicle.VehicleStatus.Id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Add Customer")]
        public ActionResult CreateRetail(int id, FormCollection form)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var vehicleMsg = vehicleSvc.GetModel(id, false);

            BindVehicleRetail(ref vehicleMsg, form);

            vehicleSvc.CreateModel(vehicleMsg);

            return RedirectToAction("Display", new { id = id });
        }

        [Authorize]
        [Host("Edit Vehicle")]
        public ActionResult Edit(int id)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var vehicleObj = vehicleSvc.GetById(id);

            ViewData.Model = vehicleObj;
            ViewData["vehicleStatusId"] = BuildVehicleStatusList(vehicleObj.VehicleStatus.Id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Edit Vehicle")]
        public ActionResult Edit(int id, FormCollection form)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var modelSvc = new ModelLogic(Ticket);

            var modelId = StringUtility.ToInt(form["modelId"]);
            var modelObj = modelSvc.GetById(modelId);

            var vehicleObj = vehicleSvc.GetById(id);
            vehicleObj.VinNumber = form["vinNumber"];
            vehicleObj.ChassisNumber = form["chassisNumber"];
            vehicleObj.EngineNumber = form["engineNumber"];
            vehicleObj.WholesaleDate = StringUtility.ToDateTime(form["wholesaleDate"]);
            if (modelObj != null)
            {
                vehicleObj.Model.Id = modelObj.Id;
                vehicleObj.Model.Code = modelObj.Code;
                vehicleObj.Model.Name = modelObj.Name;
            }
            vehicleObj.CurrentDistance = StringUtility.ToInt(form["currentDistance"]);
            vehicleObj.VehicleStatus.Id = StringUtility.ToInt(form["vehicleStatusId"]);
            vehicleSvc.Update(vehicleObj);

            return RedirectToAction("Display", new { id = id });
        }

        [Authorize]
        [Host("Edit Vehicle")]
        public ActionResult EditRetail(int id)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var vehicleMsg = vehicleSvc.GetModel(id, false);

            ViewData.Model = vehicleMsg;
            ViewData["languageId"] = BuildLanguageList(vehicleMsg.Customer.Language.Id);
            ViewData["genderId"] = BuildGenderList(vehicleMsg.Customer.Gender.Id);
            ViewData["vehicleStatusId"] = BuildVehicleStatusList(vehicleMsg.Vehicle.VehicleStatus.Id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Edit Vehicle")]
        public ActionResult EditRetail(int id, FormCollection form)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var vehicleMsg = vehicleSvc.GetModel(id, false);

            BindVehicleRetail(ref vehicleMsg, form);

            vehicleSvc.UpdateModel(vehicleMsg);

            return RedirectToAction("Display", new { id = id });
        }

        [Authorize]
        [Host("Vehicle Search")]
        public ActionResult Search()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Vehicle Search")]
        public ActionResult Search(VehicleSearchRequest request)
        {
            ViewData["resultArea"] = "Policy";
            ViewData["resultController"] = "Vehicle";
            ViewData["resultAction"] = "Display";

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
                return RedirectToAction("Display", new { id = vehicleId });
            }

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Rows.Count);

            return View();
        }

        [Authorize]
        [Host("Vehicle")]
        public ActionResult Display(int id)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var msg = vehicleSvc.GetModel(id, true);
            ViewData.Model = msg;

            if (msg.Vehicle.CustomerId == 0)
            {
                return View("Display");
            }
            else
            {
                return View("DisplayRetail");
            }
        }

        [Authorize]
        [Host("Vehicle Notes")]
        public ActionResult DisplayNotes(int id)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            var results = vehicleSvc.ListNotes(id);

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Count);

            return View();
        }

        [Authorize]
        [Host("Vehicle Notes")]
        public ActionResult DisplayServiceHistory(int id)
        {
            var serviceSvc = new VehicleServiceLogic(Ticket);
            var results = serviceSvc.GetByVehicle(id);

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Count);

            return View();
        }

        private SelectList BuildLanguageList(int languageId)
        {
            var languageSvc = new LanguageLogic(Ticket);
            var languageList = languageSvc.GetAll();

            return new SelectList(languageList, "Id", "Name", languageId);
        }

        private SelectList BuildGenderList(int genderId)
        {
            var genderSvc = new GenderLogic(Ticket);
            var genderList = genderSvc.GetAll();

            return new SelectList(genderList, "Id", "Name", genderId);
        }
        
        private SelectList BuildVehicleStatusList(int statusId)
        {
            var statusSvc = new VehicleStatusLogic(Ticket);
            var statusList = statusSvc.GetAll();

            return new SelectList(statusList, "Id", "Name", statusId);
        }

        private void BindVehicleRetail(ref VehicleModel vehicleMsg, FormCollection form)
        {
            var dealerSvc = new DealerLogic(Ticket);
            var modelSvc = new ModelLogic(Ticket);

            var dealerId = StringUtility.ToInt(form["dealerId"]);
            var dealerObj = dealerSvc.GetById(dealerId);
            var modelId = StringUtility.ToInt(form["modelId"]);
            var modelObj = modelSvc.GetById(modelId);

            vehicleMsg.Vehicle.VinNumber = form["vinNumber"];
            vehicleMsg.Vehicle.ChassisNumber = form["chassisNumber"];
            vehicleMsg.Vehicle.EngineNumber = form["engineNumber"];
            vehicleMsg.Vehicle.RegistrationNumber = form["registrationNumber"];
            vehicleMsg.Vehicle.WholesaleDate = StringUtility.ToDateTime(form["wholesaleDate"]);
            vehicleMsg.Vehicle.RetailDate = StringUtility.ToDateTime(form["retailDate"]);
            vehicleMsg.Vehicle.RegistrationDate = StringUtility.ToDateTime(form["registrationDate"]);
            if (dealerObj != null)
            {
                vehicleMsg.Vehicle.Dealer.Id = dealerObj.Id;
                vehicleMsg.Vehicle.Dealer.Code = dealerObj.Code;
                vehicleMsg.Vehicle.Dealer.Name = dealerObj.Name;
            }
            if (modelObj != null)
            {
                vehicleMsg.Vehicle.Model.Id = modelObj.Id;
                vehicleMsg.Vehicle.Model.Code = modelObj.Code;
                vehicleMsg.Vehicle.Model.Name = modelObj.Name;
            }
            vehicleMsg.Vehicle.CurrentDistance = StringUtility.ToInt(form["currentDistance"]);
            vehicleMsg.Vehicle.VehicleStatus.Id = StringUtility.ToInt(form["vehicleStatusId"]);

            vehicleMsg.Customer.Title = form["title"];
            vehicleMsg.Customer.Initials = form["initials"];
            vehicleMsg.Customer.FirstName = form["firstName"];
            vehicleMsg.Customer.LastName = form["lastName"];
            vehicleMsg.Customer.ReferenceNumber = form["referenceNumber"];
            vehicleMsg.Customer.Language.Id = StringUtility.ToInt(form["languageId"]);
            vehicleMsg.Customer.Gender.Id = StringUtility.ToInt(form["genderId"]);
            vehicleMsg.Customer.PostalAddress.Line1 = form["postalAddress1"];
            vehicleMsg.Customer.PostalAddress.Line2 = form["postalAddress2"];
            vehicleMsg.Customer.PostalAddress.Line3 = form["postalAddress3"];
            vehicleMsg.Customer.PostalAddress.Line4 = form["postalAddress4"];
            vehicleMsg.Customer.PostalAddress.PostCode = form["postalAddressCode"];
            vehicleMsg.Customer.PhysicalAddress.Line1 = form["physicalAddress1"];
            vehicleMsg.Customer.PhysicalAddress.Line2 = form["physicalAddress2"];
            vehicleMsg.Customer.PhysicalAddress.Line3 = form["physicalAddress3"];
            vehicleMsg.Customer.PhysicalAddress.Line4 = form["physicalAddress4"];
            vehicleMsg.Customer.PhysicalAddress.PostCode = form["physicalAddressCode"];
            vehicleMsg.Customer.HomePhoneNumber = form["homePhoneNumber"];
            vehicleMsg.Customer.WorkPhoneNumber = form["workPhoneNumber"];
            vehicleMsg.Customer.MobileNumber = form["mobileNumber"];
            vehicleMsg.Customer.FaxNumber = form["faxNumber"];
            vehicleMsg.Customer.EmailAddress = form["emailAddress"];
        }
    }
}