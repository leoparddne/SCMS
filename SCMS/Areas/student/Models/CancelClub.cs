using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.Areas.student.Models
{
    public class CancelClub
    {
        bool hasRun;
        Model.club club;
        bool result;
        public bool HasRun { get => hasRun; set => hasRun = value; }
        public club Club { get => club; set => club = value; }
        public bool Result { get => result; set => result = value; }
    }
}