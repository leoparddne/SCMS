using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clubManagerDAL : BaseDAL<clubmanager>
    {
        /// <summary>
        /// 在这里声明实例化一个UserDAL的对象
        /// </summary>
        public static readonly clubManagerDAL dal = new clubManagerDAL();
        public clubManagerDAL() { }
    }
}
