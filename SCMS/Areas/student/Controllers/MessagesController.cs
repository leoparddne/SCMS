using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.student.Controllers
{
    [StudentExceptionFilter]
    public class MessagesController : BaseController
    {
        // GET: student/Messages
        public ActionResult Index()
        {
            int userid = Common.User.GetUserID(Session["Username"].ToString());
            //获取所有未读的信息
            var list = new BLL.messageBLL().GetModels(p=>p.to==userid & p.state==0);
            return View(list);
        }
        public ActionResult Read(int id)
        {
            var bll = new BLL.messageBLL();
            var model = bll.GetModel(p => p.id == id);
            model.id = id;
            model.state = 1;
            bll.Update(model, new[] { "id", "state" });
            int userid = Common.User.GetUserID(Session["Username"].ToString());
            var list = bll.GetModels(p => p.to == userid & p.state == 0);
            //更新通知个数
            ViewBag.Message = bll.GetRecordCount(p => p.to == userid & p.state == 0);
            return View("Index",list);
        }
    }
}