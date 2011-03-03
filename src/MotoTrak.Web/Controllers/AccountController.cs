using System;
using System.Web;
using System.Web.Mvc;
using MotoTrak.BusinessLogic;

namespace MotoTrak.Web.Controllers
{
    public class AccountController : ApplicationController
    {
        [Host("Login")]
        public ActionResult Login(string returnUrl)
        {
            var userCode = "";
            var defaultCookie = HttpContext.Request.Cookies["defaultCredentials"];
            if (defaultCookie != null)
            {
                userCode = defaultCookie.Value;
            }

            ViewData.Add("returnUrl", returnUrl);
            ViewData.Add("userName", userCode);

            return View();
        }

        [HttpPost()]
        [Host("Login")]
        public ActionResult Login(FormCollection values, string returnUrl)
        {
            var userCode = values["userName"];
            var password = values["password"];
            var rememberMe = values["rememberMe"] == "on" ? true : false;

            var userSvc = new UserLogic(Ticket);
            userSvc.Authenticate(userCode, password);

            if (!userSvc.Authenticate(userCode, password))
            {
                DisplayError(userSvc.ErrorMessage);
                ViewData.Add("returnUrl", returnUrl);
                ViewData.Add("userName", userCode);

                return View();
            }

            if (rememberMe)
            {
                var defaultCookie = new HttpCookie("defaultCredentials", userCode);
                defaultCookie.Expires = DateTime.Now.AddMonths(1);
                HttpContext.Response.Cookies.Add(defaultCookie);
            }

            if (string.IsNullOrEmpty(returnUrl))
            {
                return Redirect("~/");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }

        public ActionResult Logout()
        {
            Ticket.UserId = 0;
            Ticket.UserCode = "";
            Ticket.UserName = "";
            Ticket.DealerId = 0;

            return RedirectToAction("Login");
        }

        [Authorize]
        [Host("Profile")]
        public ActionResult Profile()
        {
            var userSvc = new UserLogic(Ticket);
            ViewData.Model = userSvc.GetCurrent();

            return View();
        }

        [Authorize]
        [Host("Edit Profile")]
        public ActionResult EditProfile()
        {
            var userSvc = new UserLogic(Ticket);
            ViewData.Model = userSvc.GetCurrent();

            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Edit Profile")]
        public ActionResult EditProfile(FormCollection form)
        {
            var userSvc = new UserLogic(Ticket);
            var userObj = userSvc.GetCurrent();

            userObj.Name = form["name"];
            userObj.PhoneNumber = form["phoneNumber"];
            userObj.MobileNumber = form["mobileNumber"];
            userObj.EmailAddress = form["emailAddress"];

            userSvc.Save(userObj);

            Ticket.UserName = form["name"];
            DisplayInformation("Your profile has been updated successfully.");

            return RedirectToAction("Profile");
        }

        [Authorize]
        [Host("Change Password")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Host("Change Password")]
        public ActionResult ChangePassword(FormCollection form)
        {
            var oldPassword = form["oldPassword"];
            var newPassword = form["newPassword"];

            var userSvc = new UserLogic(Ticket);
            if (userSvc.ChangePassword(oldPassword, newPassword))
            {
                DisplayInformation("Your password has been successfully changed.");
                return RedirectToAction("Profile");
            }
            else
            {
                DisplayError(userSvc.ErrorMessage);
                return View();
            }
        }
    }
}