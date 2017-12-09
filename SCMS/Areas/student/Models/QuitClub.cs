using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SCMS.Areas.student.Models
{
    public class QuitClub
    {
        bool hasRun;
        Model.club club;
        bool result;
        public bool HasRun { get => hasRun; set => hasRun = value; }
        public club Club { get => club; set => club = value; }
        public bool Result { get => result; set => result = value; }
    }
}