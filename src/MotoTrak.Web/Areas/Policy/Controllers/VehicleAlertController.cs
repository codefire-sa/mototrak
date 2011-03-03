using System;
using System.Web.Mvc;
using MotoTrak.Entities;
using MotoTrak.BusinessLogic;
using Codefire.Extensions;

namespace MotoTrak.Web.Areas.Policy.Controllers
{
    public class VehicleAlertController : ApplicationController
    {
        [Authorize]
        [Host("Vehicle Alerts")]
        public ActionResult Search()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Vehicle Alerts")]
        public ActionResult Search(VehicleSearchRequest request)
        {
            ViewData["resultArea"] = "Policy";
            ViewData["resultController"] = "VehicleAlert";
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
                return RedirectToAction("Display", new { id = vehicleId });
            }

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Rows.Count);

            return View();
        }
        
        [Authorize]
        [Host("Vehicle Alerts")]
        public ActionResult List(int id)
        {
            return View();
        }
    }
}