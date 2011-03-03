using System;
using System.Web.Mvc;
using MotoTrak.Entities;
using MotoTrak.BusinessLogic;
using Codefire.Extensions;

namespace MotoTrak.Web.Areas.Claim.Controllers
{
    public class ClaimController : ApplicationController
    {
        [Authorize]
        [Host("New Claim")]
        public ActionResult VehicleSearch()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("New Claim")]
        public ActionResult VehicleSearch(VehicleSearchRequest request)
        {
            ViewData["resultArea"] = "Claim";
            ViewData["resultController"] = "Claim";
            ViewData["resultAction"] = "DisplayVehicle";

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
                return RedirectToAction("DisplayVehicle", new { id = vehicleId });
            }

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Rows.Count);

            return View();
        }

        [Authorize]
        [Host("New Claim")]
        public ActionResult DisplayVehicle(int id)
        {
            var vehicleSvc = new VehicleLogic(Ticket);
            ViewData.Model = vehicleSvc.GetSummary(id);

            return View();
        }

        [Authorize]
        [Host("Claim Queue")]
        public ActionResult Queue()
        {
            var claimSvc = new ClaimLogic(Ticket);
            var results = claimSvc.GetQueue();

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Rows.Count);

            return View();
        }

        [Authorize]
        [Host("Claim Search")]
        public ActionResult Search()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Claim Search")]
        public ActionResult Search(ClaimSearchRequest request)
        {
            ViewData["claimCode"] = request.ClaimCode;
            ViewData["jobCardNumber"] = request.JobCardNumber;
            ViewData["externalNumber"] = request.ExternalNumber;
            ViewData["dealerName"] = request.DealerName;
            ViewData["vinNumber"] = request.VinNumber;
            ViewData["chassisNumber"] = request.ChassisNumber;
            ViewData["limit"] = request.Limit;

            var claimSvc = new ClaimLogic(Ticket);
            var results = claimSvc.Search(request);

            if (results.Rows.Count == 1)
            {
                int claimId = results.Rows[0].Get<int>("Id");
                return RedirectToAction("Display", new { id = claimId, controller = "WarrantyClaim", area = "Claim" });
            }

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Rows.Count);

            return View();
        }

        [Authorize]
        [Host("Claim Notes")]
        public ActionResult DisplayNotes(int id)
        {
            var claimSvc = new ClaimLogic(Ticket);
            var results = claimSvc.ListNotes(id);

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Count);

            return View();
        }

        [Authorize]
        [Host("Claim Status History")]
        public ActionResult DisplayStatusHistory(int id)
        {
            var claimSvc = new ClaimLogic(Ticket);
            var results = claimSvc.ListStatusHistory(id);

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Count);

            return View();
        }

        [Authorize]
        [Host("Claim History")]
        public ActionResult DisplayClaimHistory(int id)
        {
            return View();
        }
    }
}