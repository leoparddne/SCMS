using Model;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace DAL
{
    class EFContextFactory
    {
        #region 从线程的数据槽中获得上下文对象
        /// <summary>
        /// 从线程的数据槽中获得上下文对象
        /// </summary>
        /// <returns></returns>
        public static DbContext GetDbContextFromContext()
        {
            DbContext context = CallContext.GetData("Dbcontext") as scmsEntities;
            if (context == null)
            {
                context = new scmsEntities();
                CallContext.SetData("Dbcontext", context);
            }
            return context;
        }
        #endregion
    }
}
