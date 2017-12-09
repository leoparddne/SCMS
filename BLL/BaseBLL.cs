using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL;
namespace BLL
{
    public abstract class BaseBLL<T> where T : class, new()
    {
        /// <summary>
        /// 构造方法中，创建仓储。
        /// </summary>
        public BaseBLL()
        {
            SetCurrentRepository();
        }
        /// <summary>
        /// CurrentRepository属性在BaseBLL的子类中用到
        /// </summary>
        protected BaseDAL<T> CurrentRepository
        {
            get;
            set;
        }
        //设置成抽象方法，子类继承时，应该重写抽象方法。
        public abstract void SetCurrentRepository();


        /// <summary>
        /// 根据查询条件获取单个实体
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T GetModel(Expression<Func<T, bool>> condition)
        {
            return CurrentRepository.GetModel(condition);
        }
        public List<T> GetModelList()
        {
            return CurrentRepository.GetModelList();
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> condition)
        {
            return CurrentRepository.GetModels(condition);
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetList()
        {
            return CurrentRepository.GetList();
        }
        /// <summary>
        /// 获取条件获取相应的数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> condition)
        {
            return CurrentRepository.GetList(condition);
        }
        public T GetModelById(params object[] keyValues)
        {
            return CurrentRepository.GetModelById(keyValues);
        }
        public bool Exist(Expression<Func<T, bool>> condition)
        {
            return CurrentRepository.Exist(condition);
        }

        public void Add(T model)
        {
            CurrentRepository.Add(model);
        }

        public void Update(T model, string[] propertyName)
        {
            CurrentRepository.Edit(model, propertyName);
        }

        public void Delete(T model, bool isAddedEFContext)
        {
            CurrentRepository.Delete(model, isAddedEFContext);
        }

        public int GetRecordCount()
        {
            return CurrentRepository.GetRecordCount();
        }
        public int GetRecordCount(Expression<Func<T, bool>> condition)
        {
            return CurrentRepository.GetRecordCount(condition);
        }
    }
}
