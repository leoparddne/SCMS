using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.Areas.student.Models
{
    /// <summary>
    /// 学生后台的公共数据显示
    /// </summary>
    public class DushBoard
    {
        int clubs;
        int mine;
        int newClubs;
        int message;
        int activity;
        int mineActivity;
        public int Clubs { get => clubs; set => clubs = value; }
        public int Mine { get => mine; set => mine = value; }
        public int NewClubs { get => newClubs; set => newClubs = value; }
        public int Message { get => message; set => message = value; }
        public int Activity { get => activity; set => activity = value; }
        public int MineActivity { get => mineActivity; set => mineActivity = value; }
    }
}