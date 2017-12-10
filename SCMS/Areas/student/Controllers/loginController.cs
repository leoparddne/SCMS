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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: student/login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CheckPwd()
        {
            string pwd = Request.Params["pwd"];
            string username = Request.Params["username"];

            try
            {
                var result = Common.Auth.CheckPwd(pwd, username);

                if (result)
                {
                    Session["Username"] = username;
                    return Redirect("/student/Home");
                }
                else
                    return Redirect("/student/Login/Login?errorMSG=1");
            }
            catch (Exception)
            {
                return Redirect("/student/Login/Login?errorMSG=1");
            }
        }

        public ActionResult Logout()
        {
            ViewBag.messagename = null;
            this.Session.Abandon();
            this.Response.Cookies.Add(new HttpCookie("asp.net_session", string.Empty) { HttpOnly = true });
            return Redirect("/");
        }
    }
}