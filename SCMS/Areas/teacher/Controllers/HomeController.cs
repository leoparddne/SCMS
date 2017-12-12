using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.teacher.Controllers
{
    public class HomeController : BaseController
    {
        // GET: teacher/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}