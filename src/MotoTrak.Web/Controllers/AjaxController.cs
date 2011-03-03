using System;
using System.Web.Mvc;
using MotoTrak.Entities;
using MotoTrak.BusinessLogic;

namespace MotoTrak.Web.Controllers
{
    public class AjaxController : ApplicationController
    {
        public ActionResult GetCustomerConcern(string code)
        {
            var concernSvc = new CustomerConcernLogic(Ticket);
            var ajaxObj = concernSvc.GetAjax(code);
            
            return Json(ajaxObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCondition(string code)
        {
            var conditionSvc = new ConditionLogic(Ticket);
            var ajaxObj = conditionSvc.GetAjax(code);

            return Json(ajaxObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRejectionReason(string code)
        {
            var reasonSvc = new RejectionReasonLogic(Ticket);
            var ajaxObj = reasonSvc.GetAjax(code);

            return Json(ajaxObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDealer(string code)
        {
            var dealerSvc = new DealerLogic(Ticket);
            var ajaxObj = dealerSvc.GetAjax(code);

            return Json(ajaxObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLabour(string code)
        {
            var labourSvc = new LabourLogic(Ticket);
            var ajaxObj = labourSvc.GetAjax(code);

            return Json(ajaxObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetModel(string code)
        {
            var modelSvc = new ModelLogic(Ticket);
            var ajaxObj = modelSvc.GetAjax(code);

            return Json(ajaxObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMiscellaneous(string code)
        {
            var miscellaneousSvc = new MiscellaneousLogic(Ticket);
            var ajaxObj = miscellaneousSvc.GetAjax(code);

            return Json(ajaxObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPart(string code)
        {
            var partSvc = new PartLogic(Ticket);
            var ajaxObj = partSvc.GetAjax(code);

            return Json(ajaxObj, JsonRequestBehavior.AllowGet);
        }
    }
}