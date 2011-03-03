using System.Web.Mvc;

namespace MotoTrak.Web.Areas.Policy
{
    public class PolicyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Policy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Policy_default",
                "Policy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
