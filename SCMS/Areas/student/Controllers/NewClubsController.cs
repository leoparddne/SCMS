using SCMS.Areas.student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    [StudentExceptionFilter]
    public class NewClubsController : BaseController
    {
        // GET: student/NewClubs
        public ActionResult Index()
        {
            //获取用户的id
            //获取我加入的社团数据
                int userID = Common.User.GetUserID(Session["Username"].ToString());
                var list = new BLL.newMember().GetModels(p => p.userID == userID&p.state==0);
                return View(list);
        }
        public ActionResult Cancel(int id, int run = 0)
        {
            BLL.newMember bll = new BLL.newMember();
            var newMember = bll.GetModel(p => p.id == id);
            ViewBag.clubID = newMember.id;
            var club = new BLL.ClubBLL().GetModel(p => p.id == newMember.clubID);
            var model = new CancelClub();
            model.HasRun = false;
            model.Result = false;
            model.Club = club;
            if (run == 0)
                return View(model);
            else
            {
                model.Result = ExectudeQuit(newMember.clubID);
                model.HasRun = true;

                return View(model);
            }

        }
        //执行添加操作
        public bool ExectudeQuit(int clubID)
        {
            int userID = Common.User.GetUserID(Session["Username"].ToString());

            //回传给前台view的model
            var bll = new BLL.newMember();
            //判断是否提交了社团的申请且申请未通过审核
            //state为0表示暂未审核
            bool hasApply = bll.Exist(p => (p.userID == userID & p.clubID == clubID & p.state==0));
            if (hasApply)
            {
                //删除记录
                var model = bll.GetModel(p => (p.userID == userID & p.clubID == clubID & p.state == 0));
                bll.Delete(model, false);
                ViewBag.NewClubs = bll.GetRecordCount(p => (p.userID == userID  & p.state == 0)); ;
                return true;
            }
            else
                return false;
        }
        public ActionResult Result()
        {
            int userID = Common.User.GetUserID(Session["Username"].ToString());
            var list = new BLL.newMember().GetModels(p => p.userID == userID &p.state!=0 &p.state!=3);
            //刷新视图数据
            //获取我申请的社团数
            var mine = new BLL.newMember().GetRecordCount(p => p.userID == userID & p.state == 0);
            ViewBag.Mine = mine;
            return View(list);
        }
        public ActionResult Read(int id)
        {
            var bll = new BLL.newMember();
            var model = bll.GetModel(p => p.id == id);
            model.state = 3;
            bll.Update(model, new[] { "id","state"});
            int userID = Common.User.GetUserID(Session["Username"].ToString());
            ViewBag.ApplyResult = bll.GetRecordCount(p => p.userID == userID & p.state != 0 & p.state != 3);
            var list = new BLL.newMember().GetModels(p => p.userID == userID & p.state != 0 & p.state != 3);
            return View("Result", list);
        }
    }
}