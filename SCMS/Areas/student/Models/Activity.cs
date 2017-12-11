using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.Areas.student.Models
{
    public class Activity
    {
        int clubID;
        string clubName;
        int activityID;
        string activityName;
        string activityPlace;
        DateTime activityTime;
        string activityInfo;

        public int ClubID { get => clubID; set => clubID = value; }
        public string ClubName { get => clubName; set => clubName = value; }
        public int ActivityID { get => activityID; set => activityID = value; }
        public string ActivityName { get => activityName; set => activityName = value; }
        public string ActivityPlace { get => activityPlace; set => activityPlace = value; }
        public DateTime ActivityTime { get => activityTime; set => activityTime = value; }
        public string ActivityInfo { get => activityInfo; set => activityInfo = value; }
    }
}