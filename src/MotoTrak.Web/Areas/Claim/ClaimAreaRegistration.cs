using System.Web.Mvc;

namespace MotoTrak.Web.Areas.Claim
{
    public class ClaimAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Claim";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Claim_default",
                "Claim/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
