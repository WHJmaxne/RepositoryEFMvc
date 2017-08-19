using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DAL
{
    public class BaseDAL<T> where T : class, new()
    {
        DbContext db = DbEFContextFactory.CreatDbContext();
        public bool AddEntity(T entity)
        {
            db.Set<T>().Add(entity);
            return true;
        }
        public bool DeleteEntity(T entity)
        {
            db.Set<T>().Remove(entity);
            return true;
        }
        public bool DeleteList(Expression<Func<T, bool>> where)
        {
            var dbQuery = db.Set<T>();
            var entities = db.Set<T>().Where(where).ToList();
            foreach (var entity in entities)
            {
                dbQuery.Remove(entity);
            }
            return true;
        }
        public bool EditEntity(T entity, params string[] editNames)
        {
            db.Set<T>().Attach(entity);
            DbEntityEntry entry = db.Entry<T>(entity);
            entry.State = EntityState.Unchanged;
            foreach (string editName in editNames)
            {
                entry.Property(editName).IsModified = true;
            }
            db.Configuration.ValidateOnSaveEnabled = false;
            return true;
        }
        public bool EditList(Expression<Func<T, bool>> where, string[] editNames, object[] editValues)
        {
            var editList = db.Set<T>().Where(where).ToList();
            Type t = typeof(T);
            foreach (var item in editList)
            {
                for (int i = 0; i < editNames.Length; i++)
                {
                    string editName = editNames[i];
                    PropertyInfo pi = t.GetProperty(editName);
                    pi.SetValue(item, editValues[i], null);
                }
            }
            return true;
        }
        public IEnumerable<T> LoadEntities(Expression<Func<T, bool>> where)
        {
            var entities = db.Set<T>().Where(where);
            return entities;
        }
        public IEnumerable<T> LoadOrderEntities<s>(Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc)
        {
            var temp = db.Set<T>().Where(where);
            if (isAsc)
                temp = temp.OrderBy(order);
            else
                temp = temp.OrderByDescending(order);
            return temp;
        }
        public IEnumerable<T> LoadInculdeEntities(Expression<Func<T, bool>> where, params string[] includeNames)
        {
            var dbQuery = db.Set<T>();
            foreach (string includeName in includeNames)
            {
                dbQuery.Include(includeName);
            }
            return dbQuery.Where(where);
        }
        public IEnumerable<T> LoadOrderIncludeEntities<s>(Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames)
        {
            var dbQuery = db.Set<T>();
            foreach (string includeName in includeNames)
            {
                dbQuery.Include(includeName);
            }
            var temp = dbQuery.Where(where);
            if (isAsc)
                temp = temp.OrderBy(order);
            else
                temp = temp.OrderByDescending(order);
            return temp;
        }
        public IEnumerable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, out int pageCount, Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames)
        {
            var dbQuery = db.Set<T>();
            foreach (string includeName in includeNames)
            {
                dbQuery.Include(includeName);
            }
            IOrderedQueryable<T> dbOrder = null;
            if (isAsc)
                dbOrder = dbQuery.OrderBy(order);
            else
                dbOrder = dbQuery.OrderByDescending(order);
            var temp = dbOrder.Where(where).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            totalCount = dbOrder.Where(where).Count();
            pageCount = Convert.ToInt32(Math.Ceiling(totalCount * 1.0 / pageSize));
            return temp;
        }
        public IEnumerable<T> LoadPageModelEntities<s>(Model.FormatModel.PageModel pageData, Expression<Func<T, bool>> where, Expression<Func<T, s>> order, bool isAsc, params string[] includeNames)
        {
            var dbQuery = db.Set<T>();
            foreach (string includeName in includeNames)
            {
                dbQuery.Include(includeName);
            }
            IOrderedQueryable<T> dbOrder = null;
            if (isAsc)
                dbOrder = dbQuery.OrderBy(order);
            else
                dbOrder = dbQuery.OrderByDescending(order);
            pageData.rows = dbOrder.Where(where).Skip((pageData.pageIndex - 1) * pageData.pageSize).Take(pageData.pageSize);
            pageData.total = dbOrder.Where(where).Count();

            return pageData.rows as IEnumerable<T>;
        }
        public bool ExcuteSql(string strSql, params SqlParameter[] param)
        {
            db.Database.ExecuteSqlCommand(strSql, param);
            return true;
        }
        public IEnumerable<T> ExcuteQuery<S>(string strSql, params SqlParameter[] param)
        {
            var temp = db.Database.SqlQuery<T>(strSql, param);
            return temp;
        }

    }
}
