using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class User
    {
        public static int GetUserID(string username)
        {
            var bll = new BLL.user();
            var id= bll.GetModel(p => p.name == username).id;
            return id;
        }
        public static string GetUserName(int id)
        {
            var bll = new BLL.user();
            var name = bll.GetModel(p => p.id == id).name;
            return name;
        }
    }
}
