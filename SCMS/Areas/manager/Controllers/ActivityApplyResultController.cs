using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.manager.Controllers
{
    [ManagerExceptionFilter]
    public class ActivityApplyResultController : BaseController
    {
        // GET: manager/ActivityApplyResult
        public ActionResult Index()
        {
            //刷新视图数据
            //获取我申请的社团数
            var list = GetList();
            ViewBag.Result = list.Count;
            return View(list);
        }
        public ActionResult Read(int id)
        {
            var bll = new BLL.clubActivity();
            var model = bll.GetModel(p => p.id == id);
            model.state = 3;
            bll.Update(model, new[] { "id", "state" });
            var list = GetList();
            ViewBag.Result = list.Count;
            return View("Index", list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Model.clubactivity> GetList()
        {
            int userID = Common.User.GetUserID(Session["Username"].ToString());
            //获取我管理的所有社团的活动申请结果
            var clubList = new BLL.clubManager().GetModels(p => p.userID == userID);
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
            return list;
        }
    }
}