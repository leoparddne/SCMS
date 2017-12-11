using SCMS.Areas.student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    [StudentExceptionFilter]
    public class ClubsController : BaseController
    {
        // GET: student/Clubs
        public ActionResult Index()
        {
            //获取所有社团数据
            var list = new BLL.ClubBLL().GetModelList();
            
            return View(list);
        }
        public ActionResult Add(int id, int run=0)
        {
            ViewBag.clubID = id;
            var club = new BLL.ClubBLL().GetModel(p => p.id == id);
            var model = new AddClub();
            model.Club = club;
            if (run == 0)
                return View(model);
            else
            {
                var tempModel = exectudeAdd(id);
                tempModel.Club = club;
                return View(tempModel);
            }
                
        }
        //执行添加操作
        public AddClub exectudeAdd(int id)
        {
            var bll = new BLL.newMember();
            int userid = Common.User.GetUserID(Session["Username"].ToString());
            var model = new Model.newmember()
            {
                userID = userid,
                clubID = id,
                time = DateTime.Now,
                state = 0
            };

            //回传给前台view的model
            //通过设置默认值为true，可精简代码
            var viewModel = new AddClub() { HasJoined = true, HasApply = true};
            //判断是否加入了社团
            bool hasJoind = new BLL.clubMember().Exist(p => (p.userid == userid & p.clubid == id));
            if (!hasJoind)
            {
                viewModel.HasJoined = false;
                //未加入社团时才判断是否申请过并没有被审核
                //判断是否申请了社团
                bool hasApply = bll.Exist(p => (p.userID == userid & p.clubID == id & p.state == 0));
                if (!hasApply)
                {
                    viewModel.HasApply = false;
                    viewModel.HasRun = true;
                    bll.Add(model);
                }
            }
            return viewModel;
        }
        public ActionResult Info(int id)
        {
            var model = new BLL.ClubBLL().GetModel(p=>p.id==id);;
            return View(model);

        }
    }
}