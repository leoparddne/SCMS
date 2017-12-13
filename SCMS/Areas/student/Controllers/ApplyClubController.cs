using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    [StudentExceptionFilter]
    public class ApplyClubController : BaseController
    {
        /// <summary>
        /// 申请中的所有活动
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            int userID = Common.User.GetUserID(Session["Username"].ToString());
            List<Model.newclub> list = new BLL.newClub().GetModels(p => p.userID == userID &p.state==0).ToList();
            ViewBag.ClubApply = list.Count;
            return View(list);
        }
        /// <summary>
        /// 所有未读的申请
        /// </summary>
        /// <returns></returns>
        public List<Model.newclub> NoneRead()
        {
            int userID = Common.User.GetUserID(Session["Username"].ToString());
            List<Model.newclub> list = new BLL.newClub().GetModels(p => p.userID == userID & p.state != 0 & p.state != 3).ToList();
            ViewBag.ClubApplyResult = list.Count;
            return list;
        }
        public ActionResult Result()
        {
            return View(NoneRead());
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult ExecAdd()
        {
            try
            {
                //判断是否具有同名社团
                var bll = new BLL.newClub();
                if(bll.Exist(p=>p.name== Request.QueryString["name"]))
                {
                    ViewBag.Success = false;
                    return View("Add");
                }
                var model = new Model.newclub();
                model.describe = Request.QueryString["des"];
                model.logo = Request.QueryString["logo"];
                model.name = Request.QueryString["name"];
                model.state = 0;
                model.userID = Common.User.GetUserID(Session["Username"].ToString());
                bll.Add(model);
                ViewBag.Success = true;
                return View("Add");
            }
            catch (Exception)
            {
                ViewBag.Success = false;
                return View("Add");
            }
        }
        public ActionResult Read(int id)
        {
            var bll = new BLL.newClub();
            var model = bll.GetModel(p => p.id == id);
            model.state = 3;
            //更新未读消息个数

            return View("Result",NoneRead());
        }
    }
}