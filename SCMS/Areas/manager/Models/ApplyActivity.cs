using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.Areas.manager.Models
{
    public class ApplyActivity
    {
        List<string> activities;

        public List<string> Activities { get => activities; set => activities = value; }
    }
}