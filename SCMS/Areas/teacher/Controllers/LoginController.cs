using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.teacher.Controllers
{
    public class LoginController : Controller
    {
        // GET: teacher/Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult checkPwd()
        {
            string pwd = Request.Params["pwd"];
            string username = Request.Params["username"];
            BLL.user bll = new BLL.user();
            try
            {
                var result = Common.Auth.CheckPwd(pwd, username);

                if (result)
                {
                    BLL.user userBll = new BLL.user();
                    var model = userBll.GetModel(p => p.name == username);
                    BLL.teacher teacherBll = new BLL.teacher();

                    var exist = teacherBll.Exist(p => p.userID == model.id);
                    if (exist)
                        return Redirect("/teacher/Home");
                    else
                        return Redirect("/teacher/Login/Login?errorMSG=2");
                }
                else
                    return Redirect("/teacher/Login/Login?errorMSG=1");
            }
            catch (Exception)
            {
                return Redirect("/teacher/Login/Login?errorMSG=1");
            }
        }
    }
}