using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.Areas.student.Models
{
    public class ActivityMoreInfo
    {
        Activity activity;
        List<Model.comment> comments;
        bool hasRun=false;
        bool result=false;

        public Activity Activity { get => activity; set => activity = value; }
        public List<Model.comment> Comments { get => comments; set => comments = value; }
        public bool HasRun { get => hasRun; set => hasRun = value; }
        public bool Result { get => result; set => result = value; }
    }
}