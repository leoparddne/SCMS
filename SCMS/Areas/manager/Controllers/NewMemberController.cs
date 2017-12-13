using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.manager.Controllers
{
    public class NewMemberController : Controller
    {
        // GET: manager/NewMember
        public ActionResult Index()
        {
            int userID = Common.User.GetUserID(Session["Username"].ToString());
            //获取我管理的所有社团的活动申请结果
            var clubList = new BLL.clubManager().GetModels(p => p.userID == userID);
            //获取这些社团的活动信息
            var list = new List<Model.newmember>();
            foreach (var item in clubList)
            {
                var act = new BLL.newMember().GetModels(p => p.clubID == item.cludID & p.state ==0);
                foreach (var j in act)
                {
                    list.Add(j);
                }
            }
            
            return View(list);
        }
        
        public ActionResult Allow(int id)
        {
            ExecquteUpdate(id,1);
            return View("Index");
        }
        public ActionResult Deny(int id)
        {
            ExecquteUpdate(id, 2);
            return View("Index");
        }
        public void ExecquteUpdate(int id,int state)
        {
            var bll = new BLL.newMember();
            var model = bll.GetModel(p => p.id == id);
            model.state = state;
            //通过申请后加入社团成员表
            if (state==1)
            {
                var member = new Model.clubmember();
                member.clubid = model.clubID;
                member.date = DateTime.Now;
                member.userid = model.userID;
                new BLL.clubMember().Add(member);
            }
            bll.Update(model,new[] { "id","state"});
        }
    }
}