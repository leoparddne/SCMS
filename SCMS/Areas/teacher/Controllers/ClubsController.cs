using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.teacher.Controllers
{
    public class ClubsController : BaseController
    {
        // GET: teacher/Clubs
        public ActionResult Index()
        {
            return View();
        }
    }
}