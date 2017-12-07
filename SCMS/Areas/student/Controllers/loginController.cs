using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    public class LoginController : Controller
    {
        // GET: student/login
        public ActionResult login()
        {
            return View();
        }
    }
}