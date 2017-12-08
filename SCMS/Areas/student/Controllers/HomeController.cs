using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    public class HomeController : Controller
    {
        // GET: student/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}