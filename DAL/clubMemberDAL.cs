using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clubMemberDAL : BaseDAL<clubmember>
    {
        /// <summary>
        /// 在这里声明实例化一个UserDAL的对象
        /// </summary>
        public static readonly clubMemberDAL dal = new clubMemberDAL();
        public clubMemberDAL() { }
    }
}
