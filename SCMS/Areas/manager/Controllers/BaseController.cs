using SCMS.Areas.student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.manager.Controllers
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
            if (!new BLL.clubMember().Exist(p => p.userid == userModel.id))
            {
                //返回用户登录界面
                Response.Redirect("/manager/Login/Login");
            }
            //获取所有社团数
            DushBoard model = new DushBoard();
            model.Clubs = new BLL.ClubBLL().GetRecordCount();
            //获取我加入的社团数
            model.Mine = new BLL.clubMember().GetRecordCount(p => p.userid == userModel.id);
            //获取申请中的新社团
            model.NewClubs = new BLL.newMember().GetRecordCount(p => p.userID == userModel.id & p.state == 0);

            ViewBag.Clubs = model.Clubs;
            ViewBag.Mine = model.Mine;
            ViewBag.NewClubs = model.NewClubs;

            //获取通知与活动个数
            ViewBag.Message = new BLL.messageBLL().GetRecordCount(p => p.to == userModel.id & p.state == 0);
            ViewBag.Activity = new BLL.clubActivity().GetRecordCount();
            //获取我所有加入的社团，然后查询
            int count = 0;
            var mineClubs = new BLL.clubMember().GetModels(p => p.userid == userModel.id);
            foreach (var item in mineClubs)
            {
                count += new BLL.clubActivity().GetRecordCount(p => p.clubID == item.clubid);
            }
            ViewBag.mineActivity = count;
            //获取未读申请结果个数
            ViewBag.ApplyResult = new BLL.newMember().GetRecordCount(p => p.userID == userModel.id & p.state != 0 & p.state != 3);
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