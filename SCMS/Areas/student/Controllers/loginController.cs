using BLL;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;
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
        public ActionResult checkPwd()
        {
            string pwd = Request.Params["pwd"];
            string username = Request.Params["username"];

            try
            {
                var result = Common.Auth.CheckPwd(pwd, username);

                if (result)
                    return Redirect("/student/Home");
                else
                    return Redirect("/student/Login/Login?errorMSG=1");
            }
            catch (Exception)
            {
                return Redirect("/student/Login/Login?errorMSG=1");
            }
        }
    }
}