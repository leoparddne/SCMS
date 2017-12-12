using SCMS.Areas.student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.teacher.Controllers
{
    [TeacherExceptionFilter]
    public class NewActivityController : BaseController
    {
        // GET: teacher/NewActivity
        public ActionResult Index()
        {
            List<Activity> list = new List<Activity>();
            //获取未审核的活动
            var activities = new BLL.clubActivity().GetList(p => p.state == 0);
            //将需要的社团活动信息填充入list

            foreach (var item in activities)
            {
                var model = new Activity();
                model.ActivityID = item.id;
                model.ActivityInfo = item.other;
                model.ActivityName = item.name;
                model.ActivityPlace = item.place;
                model.ActivityTime = item.time;
                model.ClubID = item.clubID;
                model.ClubName = Common.Club.getClubName(item.clubID);
                //将活动信息添加到list中
                list.Add(model);
            }

            return View(list);
        }
        public void Allow(int id)
        {
            Update(id, 1);
            Response.Redirect("/teacher/NewActivity/");
        }
        public void Deny(int id)
        {
            Update(id, 2);
            Response.Redirect("/teacher/NewActivity/");
        }
        /// <summary>
        /// 执行申请状态更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        public void Update(int id,int state)
        {
            var bll = new BLL.clubActivity();
            var model = bll.GetModel(p => p.id == id);
            model.state = state;
            bll.Update(model, new[] { "id", "state" });
            //更新申请个数
            ViewBag.ActivityApply = new BLL.clubActivity().GetRecordCount(p => p.state == 0);
        }
    }
}