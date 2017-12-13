using SCMS.Areas.student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.manager.Controllers
{
    public class PersonalCenterController : Controller
    {
        // GET: manager/PersonalCenter
        public ActionResult Index()
        {
            var result = new ChangePWD();
            result.Success = false;
            try
            {
                string oldPWD = Request.QueryString["oldPWD"];
                string newPWD = Request.QueryString["newPWD"];
                int userID = Common.User.GetUserID(Session["Username"].ToString());
                //判断旧密码
                if (Common.Auth.CheckPwd(oldPWD, Common.User.GetUserName(userID)))
                {
                    //更新密码
                    var bll = new BLL.user();
                    var model = bll.GetModel(p => p.id == userID);
                    string pwd = Common.Auth.Encrypt(newPWD);
                    model.pwd = pwd;
                    bll.Update(model, new[] { "id", "pwd" });
                    result.Success = true;
                }
            }
            catch (Exception)
            {
                return View();
            }

            return View(result);
        }
    }
}