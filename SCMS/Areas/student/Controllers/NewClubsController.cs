using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    public class NewClubsController : BaseController
    {
        // GET: student/NewClubs
        public ActionResult Index()
        {
            //获取用户的id
            //获取我加入的社团数据
            try
            {
                int userID = Common.User.GetUserID(Session["Username"].ToString());
                var list = new BLL.newMember().GetModels(p => p.userID == userID);
                return View(list);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Cancel(int id, int run = 0)
        {
            BLL.clubMember clubMemberBll = new BLL.clubMember();
            var clubMember = clubMemberBll.GetModel(p => p.id == id);
            ViewBag.clubID = clubMember.id;
            var club = new BLL.ClubBLL().GetModel(p => p.id == clubMember.clubid);
            var model = new QuitClub();
            model.HasRun = false;
            model.Result = false;
            model.Club = club;
            if (run == 0)
                return View(model);
            else
            {
                model.Result = exectudeQuit(clubMember.clubid);
                model.HasRun = true;
                return View(model);
            }

        }
        //执行添加操作
        public bool exectudeQuit(int clubID)
        {
            int userid = Common.User.GetUserID(Session["Username"].ToString());

            //回传给前台view的model
            var viewModel = new QuitClub() { };
            var clubBll = new BLL.clubMember();
            //判断是否加入了社团
            bool hasJoind = clubBll.Exist(p => (p.userid == userid & p.clubid == clubID));
            if (hasJoind)
            {
                var model = clubBll.GetModel(p => (p.userid == userid & p.clubid == clubID));
                clubBll.Delete(model, false);
                return true;
            }
            else
                return false;
        }
    }
}