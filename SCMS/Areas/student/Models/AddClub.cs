using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SCMS.Areas.student.Models
{
    public class AddClub
    {
        int clubid;
        bool hasJoined;
        bool hasApply;
        Model.club club;
        bool hasRun;
        public bool HasJoined { get => hasJoined; set => hasJoined = value; }
        public bool HasApply { get => hasApply; set => hasApply = value; }
        public int Clubid { get => clubid; set => clubid = value; }
        public club Club { get => club; set => club = value; }
        public bool HasRun { get => hasRun; set => hasRun = value; }
    }
}