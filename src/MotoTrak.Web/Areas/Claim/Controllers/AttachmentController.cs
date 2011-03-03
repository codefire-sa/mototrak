using System;
using System.Web.Mvc;
using MotoTrak.Entities;

namespace MotoTrak.Web.Areas.Claim.Controllers
{
    public class AttachmentController : ApplicationController
    {
        [Authorize]
        [Host("Add Attachment")]
        public ActionResult Create(int id)
        {
            ViewData.Add("ClaimId", id);

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Add Attachment")]
        public ActionResult Create(int id, FormCollection form)
        {
            ViewData.Add("ClaimId", id);

            return View();
        }
    }
}