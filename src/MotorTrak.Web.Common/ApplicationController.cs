using System;
using System.Web;
using System.Web.Mvc;
using MotoTrak.Entities;
using Codefire.Storm;

namespace MotoTrak.Web
{
    public class ApplicationController : System.Web.Mvc.Controller
    {
        #region [ Properties ]

        public bool IsPostBack
        {
            get { return this.Request.HttpMethod == "POST"; }
        }

        public SecurityTicket Ticket
        {
            get
            {
                var user = User as UserIdentity;
                if (user == null)
                {
                    return new SecurityTicket();
                }
                else
                {
                    return user.Ticket;
                }
            }
        }

        #endregion

        #region [ Methods ]

        #region [ Utility ]

        protected void DisplayInformation(string msg)
        {
            SetMessage(msg, MessageType.Information);
        }

        protected void DisplayWarning(string msg)
        {
            SetMessage(msg, MessageType.Warning);
        }

        protected void DisplayError(string msg)
        {
            SetMessage(msg, MessageType.Error);
        }

        protected void ClearMessage()
        {
            TempData.Remove("hostMessage");
            TempData.Remove("hostMessageType");
        }

        #endregion

        #region [ Overrides ]

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewData.Add("hostUserName", Ticket.UserName);
        }

        #endregion

        #region [ Private ]

        private void SetMessage(string msg, MessageType type)
        {
            TempData["hostMessage"] = msg;
            TempData["hostMessageType"] = type;
        }

        #endregion

        #endregion
    }
}