using System;
using System.Web.Mvc;

namespace MotoTrak.Web
{
    public class HostAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        private string _title;

        public HostAttribute()
            : base()
        {
        }

        public HostAttribute(string title)
            : base()
        {
            _title = title;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var controller = filterContext.Controller as ApplicationController;
            if (controller != null)
            {
                controller.ViewBag.Title = _title;
            }
        }
    }
}