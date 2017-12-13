﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Areas.manager.Controllers
{
    [ManagerExceptionFilter]
    public class ClubsController : BaseController
    {
        // GET: manager/Clubs
        public ActionResult Index()
        {
            //获取所有社团数据
            var list = new BLL.ClubBLL().GetModelList();

            return View(list);
        }
        public ActionResult Info(int id)
        {
            var model = new BLL.ClubBLL().GetModel(p => p.id == id); ;
            return View(model);

        }
    }
}