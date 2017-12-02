using System.Web.Mvc;

namespace SCMS.Areas.manager
{
    public class managerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "manager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "manager_default",
                "manager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}