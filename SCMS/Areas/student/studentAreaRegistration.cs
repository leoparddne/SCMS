using System.Web.Mvc;

namespace SCMS.Areas.student
{
    public class studentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "student";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "student_new",
                "student/{controller}/{action}/{id}/{run}",
                new { action = "Index", id = UrlParameter.Optional, run = UrlParameter.Optional }
            );
            context.MapRoute(
                "student_default",
                "student/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}