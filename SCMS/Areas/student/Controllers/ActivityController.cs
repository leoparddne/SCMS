using SCMS.Areas.student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    [StudentExceptionFilter]
    public class ActivityController : BaseController
    {
        // GET: student/Activity
        public ActionResult Index()
        {
                List<Activity> list = new List<Activity>();
            //获取审核通过的活动
                var activities = new BLL.clubActivity().GetList(p=>p.state==1);
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

                return View("Mine", list);
        }
        public ActionResult Mine()
        {

            //获取用户的id
                int userID = Common.User.GetUserID(Session["Username"].ToString());
                //获取我加入的社团数据
                var mineClub = new BLL.clubMember().GetModels(p => p.userid == userID);
                var list = new List<Activity>();

                foreach (var item in mineClub)
                {
                    //获取每个社团审核通过的活动
                    var activities = new BLL.clubActivity().GetModels(p => p.clubID == item.clubid & p.state == 1);
                    //将需要的社团活动信息填充入list

                    foreach (var j in activities)
                    {
                        var model = new Activity();
                        model.ActivityID = j.id;
                        model.ActivityInfo = j.other;
                        model.ActivityName = j.name;
                        model.ActivityPlace = j.place;
                        model.ActivityTime = j.time;
                        model.ClubID = item.clubid;
                        model.ClubName = Common.Club.getClubName(item.clubid);
                        //将活动信息添加到list中
                        list.Add(model);
                    }

                }
                return View(list);
        }
        public ActionResult Info(int id)
        {
            //获取用户的id
                int userID = Common.User.GetUserID(Session["Username"].ToString());
                //获取我加入的社团数据
                    //获取每个社团审核通过的活动
                    var activities = new BLL.clubActivity().GetModel(p => p.id == id&p.state == 1);
                    //将需要的社团活动信息填充入list
                        var model = new Activity();
                        model.ActivityID = activities.id;
                        model.ActivityInfo = activities.other;
                        model.ActivityName = activities.name;
                        model.ActivityPlace = activities.place;
                        model.ActivityTime = activities.time;
                        model.ClubID = activities.clubID;
                        model.ClubName = Common.Club.getClubName(activities.clubID);
                
                var info = new ActivityMoreInfo();
                info.Activity = model;
                //获取活动的所有评论
                var comments = new BLL.comment().GetModels(p=>p.actID==id).ToList();
                info.Comments = comments;

                return View(info);
        }
        public bool UploadComment(string text)
        {
            bool result = false;
            if (text == "")
                return result;
            var activityID = Convert.ToInt32(Request.QueryString["actID"]);
            var model = new Model.comment();
            model.actID = activityID;
            model.userID= Common.User.GetUserID(Session["Username"].ToString());
            model.time = DateTime.Now;
            model.text = text;
            new BLL.comment().Add(model);
            result = true;
            return result;
        }
    }
}