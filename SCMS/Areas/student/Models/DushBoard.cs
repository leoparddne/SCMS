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
        public int Clubs { get => clubs; set => clubs = value; }
        public int Mine { get => mine; set => mine = value; }
        public int NewClubs { get => newClubs; set => newClubs = value; }
    }
}