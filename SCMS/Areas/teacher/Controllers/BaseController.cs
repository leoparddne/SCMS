using SCMS.Areas.student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.teacher.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
#if DEBUG
            ViewBag.Username = "a";

#endif
            //初始化页面数据，通过ViewBag传递给view
            //获取用户id
            BLL.user user = new BLL.user();
            string name = ViewBag.Username;
            var userModel = user.GetModel(p => p.name == name);
            //验证用户权限
            if (!new BLL.teacher().Exist(p => p.userID == userModel.id))
            {
                //返回用户登录界面
                Response.Redirect("/teacher/Login/Login?errorMSG=2");
            }
            //获取社团个数
            ViewBag.Clubs = new BLL.ClubBLL().GetRecordCount();
            //获取申请中的活动
            ViewBag.ActivityApply = new BLL.clubActivity().GetRecordCount(p => p.state == 0);
            //获取申请中的新社团
            ViewBag.ClubApply = new BLL.newClub().GetRecordCount(p => p.userID == userModel.id & p.state == 0);
        }
    }
    //自定义的异常处理
    public class TeacherExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/teacher/Home");
        }
    }
}