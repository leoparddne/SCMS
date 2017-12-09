using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Club
    {
        public static string getClubName(int clubID)
        {
            var name= new BLL.ClubBLL().GetModel(p => p.id == clubID).name;
            return name;
        }
        public static bool HasJoinedClub(int userID,int clubID)
        {
            var bll = new BLL.clubMember();
            return bll.Exist(p=>p.userid==userID &p.clubid==clubID);
        }
    }
}
