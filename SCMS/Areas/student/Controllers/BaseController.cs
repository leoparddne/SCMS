using SCMS.Areas.student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    public class BaseController: Controller
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
            
            //获取所有社团数
            DushBoard model = new DushBoard();
            model.Clubs = new BLL.ClubBLL().GetRecordCount();
            //获取我加入的社团数
            model.Mine = new BLL.clubMember().GetRecordCount(p => p.userid == userModel.id);
            //获取申请中的新社团
            model.NewClubs = new BLL.newMember().GetRecordCount(p => p.userID == userModel.id);

            ViewBag.Clubs = model.Clubs;
            ViewBag.Mine = model.Mine;
            ViewBag.NewClubs = model.NewClubs;
        }
    }
    //自定义的异常处理
    public class StudentExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/student/Home");
        }
    }
}