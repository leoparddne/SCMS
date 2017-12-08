using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.manager.Controllers
{
    public class LoginController : Controller
    {
        // GET: manager/Login
        public ActionResult Login()
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
                {
                    BLL.user userBll = new BLL.user();
                    var model = userBll.GetModel(p => p.name == username);
                    BLL.clubManager clubBll = new BLL.clubManager();

                    var exist = clubBll.Exist(p => p.userID == model.id);
                    if (exist)
                        return Redirect("/manager/Home");
                    else
                        return Redirect("/manager/Login/Login?errorMSG=2");
                }
                else
                    return Redirect("/manager/Login/Login?errorMSG=1");
            }
            catch (Exception)
            {

                return Redirect("/manager/Login/Login?errorMSG=1");
            }
        }
    }
}