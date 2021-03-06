﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.IDAL
{
    public interface IBaseDAL<T> where T : class, new()
    {
        bool AddEntity(T entity);
        bool DeleteEntity(T entity);
        bool DeleteList(System.Linq.Expressions.Expression<Func<T, bool>> where);
        bool EditEntity(T entity, params string[] editNames);
        bool EditList(Expression<Func<T, bool>> where, string[] editNames, object[] editValues);

        IQueryable<T> LoadEntities(Expression<Func<T, bool>> where);
        IQueryable<T> LoadOrderEntities<s>(Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc);
        IQueryable<T> LoadInculdeEntities(Expression<Func<T, bool>> where, params string[] includeNames);
        IQueryable<T> LoadOrderIncludeEntities<s>(Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames);
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, out int pageCount, Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames);
        IQueryable<T> LoadPageModelEntities<s>(Model.FormatModel.PageModel pageData, Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames);
        bool ExcuteSql(string strSql, params SqlParameter[] param);
        IQueryable<T> ExcuteQuery<S>(string strSql, params SqlParameter[] param);
    }
}
