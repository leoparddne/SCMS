using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.App_Start
{
    public class ViewEngine : RazorViewEngine
    {

        public ViewEngine()
        {
            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/admin/{1}/{0}.cshtml",
                "~/Views/teacher/{1}/{0}.cshtml",
                "~/Views/manager/{1}/{0}.cshtml"
            };
        }
        //public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        //{
        //    return base.FindView(controllerContext, viewName, masterName, useCache);
        //}
    }

}