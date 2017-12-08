using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class clubActivity : BaseBLL<Model.clubactivity>
    {
        /// <summary>
        /// 在这里声明实例化一个UserBLL的对象
        /// </summary>
        public static readonly clubActivity GetUserBLL = new clubActivity();
        /// <summary>
        /// 要对BaseBLL中的抽象方法进行实现。
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = clubAtivityDAL.dal;//CurrentRepository属性在BaseBLL中定义
        }
    }
}
