using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.manager.Controllers
{
    [ManagerExceptionFilter]
    public class HomeController : BaseController
    {
        // GET: manager/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}