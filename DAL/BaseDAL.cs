using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL<T> where T : class, new()
    {

        //获取EF上下文对象
        protected DbContext DataContext
        {
            get { return EFContextFactory.GetDbContextFromContext(); }
        }


        /// <summary>
        /// 根据查询条件获取单个实体
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T GetModel(Expression<Func<T, bool>> condition)
        {
            return DataContext.Set<T>().Where(condition).FirstOrDefault();
        }


        #region 新增
        public void Add(T model)
        {
            DataContext.Set<T>().Add(model);
            SaveChanges();
        }
        #endregion

        #region 编辑
        public void Edit(T model, string[] propertyName)
        {
            if (model == null)
            {
                throw new Exception("model必须为实体的对象");
            }
            if (propertyName == null || propertyName.Any() == false)
            {
                throw new Exception("必须至少指定一个要修改的属性");
            }

            //将model追加到EF容器
            var entry = DataContext.Entry(model);

            entry.State = EntityState.Unchanged;

            foreach (var item in propertyName)
            {
                entry.Property(item).IsModified = true;
            }
            SaveChanges();
        }

        #endregion

        #region 物理删除
        //EntityState.Unchanged
        public void Delete(T model, bool isAddedEFContext)
        {
            if (isAddedEFContext == false)
            {
                DataContext.Set<T>().Attach(model);
            }
            //修改状态为deleted
            DataContext.Set<T>().Remove(model);
            SaveChanges();
        }
        #endregion

        #region 统一执行保存
        public int SaveChanges()
        {
            return DataContext.SaveChanges();
        }
        #endregion
    }
}
