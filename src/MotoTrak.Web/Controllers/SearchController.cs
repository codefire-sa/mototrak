using System;
using System.Web.Mvc;
using MotoTrak.Entities;
using MotoTrak.BusinessLogic;
using Codefire.Extensions;

namespace MotoTrak.Web.Areas.Claim.Controllers
{
    public class SearchController : ApplicationController
    {
        [Authorize]
        [Host("Customer Concern Search")]
        public ActionResult CustomerConcern()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Customer Concern Search")]
        public ActionResult CustomerConcern(SearchRequest request)
        {
            ViewData["code"] = request.Code;
            ViewData["name"] = request.Name;
            ViewData["limit"] = request.Limit;

            var concernSvc = new CustomerConcernLogic(Ticket);
            var model = concernSvc.Search(request);

            return View(model);
        }

        [Authorize]
        [Host("Condition Search")]
        public ActionResult Condition()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Condition Search")]
        public ActionResult Condition(SearchRequest request)
        {
            ViewData["code"] = request.Code;
            ViewData["name"] = request.Name;
            ViewData["limit"] = request.Limit;

            var conditionSvc = new ConditionLogic(Ticket);
            var model = conditionSvc.Search(request);

            return View(model);
        }

        [Authorize]
        [Host("Rejection Reason Search")]
        public ActionResult RejectionReason()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Rejection Reason Search")]
        public ActionResult RejectionReason(SearchRequest request)
        {
            ViewData["code"] = request.Code;
            ViewData["name"] = request.Name;
            ViewData["limit"] = request.Limit;

            var reasonSvc = new RejectionReasonLogic(Ticket);
            var model = reasonSvc.Search(request);

            return View(model);
        }

        [Authorize]
        [Host("Dealer Search")]
        public ActionResult Dealer()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Dealer Search")]
        public ActionResult Dealer(SearchRequest request)
        {
            ViewData["code"] = request.Code;
            ViewData["name"] = request.Name;
            ViewData["limit"] = request.Limit;

            var dealerSvc = new DealerLogic(Ticket);
            var model = dealerSvc.Search(request);

            return View(model);
        }

        [Authorize]
        [Host("Labour Search")]
        public ActionResult Labour()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Labour Search")]
        public ActionResult Labour(SearchRequest request)
        {
            ViewData["code"] = request.Code;
            ViewData["name"] = request.Name;
            ViewData["limit"] = request.Limit;

            var labourSvc = new LabourLogic(Ticket);
            var results = labourSvc.Search(request);

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Count);

            return View();
        }

        [Authorize]
        [Host("Model Search")]
        public ActionResult Model()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Dealer Search")]
        public ActionResult Model(SearchRequest request)
        {
            ViewData["code"] = request.Code;
            ViewData["name"] = request.Name;
            ViewData["limit"] = request.Limit;

            var modelSvc = new ModelLogic(Ticket);
            var model = modelSvc.Search(request);

            return View(model);
        }

        [Authorize]
        [Host("Miscellaneous Search")]
        public ActionResult Miscellaneous()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Miscellaneous Search")]
        public ActionResult Miscellaneous(SearchRequest request)
        {
            ViewData["code"] = request.Code;
            ViewData["name"] = request.Name;
            ViewData["limit"] = request.Limit;

            var miscellaneousSvc = new MiscellaneousLogic(Ticket);
            var results = miscellaneousSvc.Search(request);

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Count);

            return View();
        }

        [Authorize]
        [Host("Part Search")]
        public ActionResult Part()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Part Search")]
        public ActionResult Part(SearchRequest request)
        {
            ViewData["code"] = request.Code;
            ViewData["name"] = request.Name;
            ViewData["limit"] = request.Limit;

            var partSvc = new PartLogic(Ticket);
            var results = partSvc.Search(request);

            ViewData.Model = results;
            ViewData.Add("resultsCount", results.Count);

            return View();
        }
    }
}