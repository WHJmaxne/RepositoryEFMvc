using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.IBLL
{
    public interface IBaseBLL<T> where T:class,new()
    {
        bool AddEntity(T entity);
        bool DeleteEntity(T entity);
        bool DeleteList(System.Linq.Expressions.Expression<Func<T, bool>> where);
        bool EditEntity(T entity, params string[] editNames);
        bool EditList(Expression<Func<T, bool>> where, string[] editNames, object[] editValues);

        IEnumerable<T> LoadEntities(Expression<Func<T, bool>> where);
        IEnumerable<T> LoadOrderEntities<s>(Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc);
        IEnumerable<T> LoadInculdeEntities(Expression<Func<T, bool>> where, params string[] inculdeNames);
        IEnumerable<T> LoadOrderIncludeEntities<s>(Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames);
        IEnumerable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, out int pageCount, Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames);
        IEnumerable<T> LoadPageModelEntities<s>(Model.FormatModel.PageModel pageData, Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames);
        bool ExcuteSql(string strSql, params SqlParameter[] param);
        IEnumerable<T> ExcuteQuery<S>(string strSql, params SqlParameter[] param);
        
    }
}
