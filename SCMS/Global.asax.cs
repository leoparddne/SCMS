using System.Web.Mvc;
using System.Web.Routing;

namespace SCMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new ViewEngine());
            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
