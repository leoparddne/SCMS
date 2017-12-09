using SCMS.Areas.student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    public class HomeController : BaseController
    {
        // GET: student/Home
        public ActionResult Index()
        {
            return View();
        }
    }

}