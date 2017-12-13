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
            if (!new BLL.clubManager().Exist(p => p.userID == userModel.id))
            {
                //返回用户登录界面
                Response.Redirect("/manager/Login/Login");
            }

            ViewBag.Clubs = new BLL.ClubBLL().GetRecordCount();
            //获取我管理的所有社团的活动申请结果
            var clubList = new BLL.clubManager().GetModels(p => p.userID == userModel.id);
            //获取这些社团的活动信息
            var list = new List<Model.clubactivity>();
            foreach (var item in clubList)
            {
                var act = new BLL.clubActivity().GetModels(p => p.clubID == item.cludID & p.state != 0 & p.state != 3);
                foreach (var j in act)
                {
                    list.Add(j);
                }
            }
            //页面申请结果数量
            ViewBag.Result = list.Count;
            //页面入社申请结果数量
            var newMember = new BLL.newMember();
            int newMemberCount = 0;
            foreach (var item in clubList)
            {
                var act = new BLL.clubActivity().GetModels(p => p.clubID == item.cludID & p.state != 0 & p.state != 3);
                newMemberCount += newMember.GetRecordCount(p => p.state == 0 & p.clubID == item.cludID);
            }
            ViewBag.NewMember = newMemberCount;
        }
    }
    //自定义的异常处理
    public class ManagerExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/manager/Home");
        }
    }
}