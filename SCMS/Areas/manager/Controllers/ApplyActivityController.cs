using SCMS.Areas.manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.manager.Controllers
{
    [ManagerExceptionFilter]
    public class ApplyActivityController : BaseController
    {
        // GET: manager/ApplyActivity
        public ActionResult Index()
        {
            
            
            
            
            return View(getInfo());
        }

        /// <summary>
        /// 获取我管理的所有社团的活动申请结果
        /// </summary>
        /// <returns></returns>
        public ApplyActivity getInfo()
        {
            int userID = Common.User.GetUserID(Session["Username"].ToString());
            var clubList = new BLL.clubManager().GetModels(p => p.userID == userID);
            var info = new ApplyActivity();
            info.Activities = new List<string>();
            foreach (var item in clubList)
            {
                //获取社团名称
                info.Activities.Add(Common.Club.getClubName(item.cludID));
            }
            return info;
        }
        public ActionResult Add()
        {
            try
            {
                //页面初始值
                ViewBag.Success = true;
                int userID = Common.User.GetUserID(Session["Username"].ToString());
                var model = new Model.clubactivity();
                model.clubID = Common.Club.getClubID(Request.QueryString["clubName"]);
                model.name = Request.QueryString["name"];
                model.other = Request.QueryString["other"];
                model.place = Request.QueryString["place"];
                model.state = 0;
                DateTime time = new DateTime();
                time = Convert.ToDateTime(Request.QueryString["date"]);
                //检测时间是否已经过去
                if(time<DateTime.Now.AddDays(1))
                {
                    ViewBag.Success = false;
                }
                else
                {
                    new BLL.clubActivity().Add(model);
                }
               
                
                //控制页面显示
                
                return View("Index", getInfo());
            }
            catch (Exception)
            {
                ViewBag.Success = false;
                return View("Index", getInfo());
            }
          
            
        }
    }
}