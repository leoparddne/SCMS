using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.teacher.Controllers
{
    [TeacherExceptionFilter]
    public class NewClubController : BaseController
    {
        // GET: teacher/NewClub
        public ActionResult Index()
        {
            //获取所有社团数据
            var list = new BLL.newClub().GetModels(p=>p.state==0).ToList();

            return View(list);
        }
        public void Allow(int id)
        {
            Update(id, 1);
            //社团表中加入新的社团
            var bll = new BLL.newClub();
            var model = bll.GetModel(p => p.id == id); 
             var clubBLL = new BLL.ClubBLL();
            var clubModel = new Model.club();
            clubModel.date = DateTime.Now;
            clubModel.logo = model.logo;
            clubModel.name = model.name;
            clubBLL.Add(clubModel);
            Response.Redirect("/teacher/NewClub/");
        }
        public void Deny(int id)
        {
            Update(id, 2);
            Response.Redirect("/teacher/NewClub/");
        }
        /// <summary>
        /// 执行申请状态更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        public void Update(int id, int state)
        {
            var bll = new BLL.newClub();
            var model = bll.GetModel(p => p.id == id);
            model.state = state;
            bll.Update(model, new[] { "id", "state" });
            //更新申请个数
            ViewBag.ClubApply = new BLL.newClub().GetRecordCount(p => p.state == 0);
        }
    }
}