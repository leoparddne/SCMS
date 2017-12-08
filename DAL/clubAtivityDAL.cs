using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clubAtivityDAL : BaseDAL<clubactivity>
    {
        /// <summary>
        /// 在这里声明实例化一个UserDAL的对象
        /// </summary>
        public static readonly clubAtivityDAL dal = new clubAtivityDAL();
        public clubAtivityDAL() { }
    }
}
