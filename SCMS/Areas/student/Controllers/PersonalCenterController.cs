using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    public class PersonalCenterController : BaseController
    {
        // GET: student/PersonalCenter
        public ActionResult Index()
        {
            return View();
        }
    }
}