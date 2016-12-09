using EFCodeFirst.IDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.BLL
{
   public abstract class BaseBLL<T> where T :class,new()
    {
       public IDBSession DbSession
       {
           get
           {
               return DALFactory.DbSessionFactory.CreatDbSession();
           }
       }
       public IBaseDAL<T> CurrentDAL { get; set; }
       public abstract void SetCurrent();
       public BaseBLL()
       {
           SetCurrent();
       }
        public bool AddEntity(T entity)
        {
            return CurrentDAL.AddEntity(entity);
        }
        public bool DeleteEntity(T entity)
        {
            return CurrentDAL.DeleteEntity(entity);
        }
        public bool DeleteList(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return CurrentDAL.DeleteList(where);
        }
        public bool EditEntity(T entity, params string[] editNames)
        {
            return CurrentDAL.EditEntity(entity, editNames);
        }
        public bool EditList(Expression<Func<T, bool>> where, string[] editNames, object[] editValues)
        {
            return CurrentDAL.EditList(where, editNames, editValues);
        }
        public IEnumerable<T> LoadEntities(Expression<Func<T, bool>> where)
        {
            return CurrentDAL.LoadEntities(where);
        }
        public IEnumerable<T> LoadOrderEntities<s>(Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc)
        {
            return CurrentDAL.LoadOrderEntities<s>(where, order, isAsc);
        }
        public IEnumerable<T> LoadInculdeEntities(Expression<Func<T, bool>> where, params string[] includeNames)
        {
            return CurrentDAL.LoadInculdeEntities(where, includeNames);
        }
        public IEnumerable<T> LoadOrderIncludeEntities<s>(Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames)
        {
            return CurrentDAL.LoadOrderIncludeEntities(where, order, isAsc, includeNames);
        }
        public IEnumerable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, out int pageCount, Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames)
        {
            return CurrentDAL.LoadPageEntities<s>(pageIndex, pageSize,out totalCount,out pageCount, where, order, isAsc, includeNames);
        }
        public IEnumerable<T> LoadPageModelEntities<s>(Model.FormatModel.PageModel pageData, Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames)
        {
            return CurrentDAL.LoadPageModelEntities<s>(pageData, where, order, isAsc, includeNames);
        }
        public bool ExcuteSql(string strSql, params SqlParameter[] param)
        {
            return CurrentDAL.ExcuteSql(strSql, param);
        }
        public IEnumerable<T> ExcuteQuery<S>(string strSql, params SqlParameter[] param)
        {
            return CurrentDAL.ExcuteQuery<S>(strSql, param);
        }
    }
}
