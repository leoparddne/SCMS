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
        public void checkPwd()
        {
            string pwd = Request.Params["pwd"];
            string username = Request.Params["username"];
            BLL.user bll = new BLL.user();
            var result=Common.Auth.CheckPwd(pwd, username);
            //ClubBLL bll = new ClubBLL();
            //var model = bll.GetModel(p => p.id == 2);
            //return View();
        }
    }
}