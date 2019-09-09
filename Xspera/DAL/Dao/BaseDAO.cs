using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Xspera.DAL.Entities;

namespace Xspera.DAL.Dao
{

    /// <summary>
    /// Define base DAO.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="Repository.DAO.IDao{T}" />
    /// <seealso cref="ImageDBContext" />
    /// <seealso cref="ImageDBContext" />
    public class BaseDao<T, TContext> : IDao<T>
        where T : class
        where TContext : XsperaContext
    {
        /// <summary>
        /// The context
        /// </summary>
        protected TContext Context;

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <value>
        /// The session.
        /// </value>
        public TContext Session => this.Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDao{T, TContext}" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public BaseDao(TContext session)
        {
            this.Context = session;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Add(T entity)
        {
            var result = this.Context.Add(entity);
            this.Context.SaveChanges();

            return result;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void AddRange(List<T> entities)
        {
            this.Context.AddRange(entities);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(T entity)
        {
            this.Context.Remove(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(object key)
        {
            var removeEntity = this.Context.Find<T>(key);
            this.Context.Remove(removeEntity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(T entity)
        {
            this.Context.Update(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Get(object key)
        {
            return this.Context.Find<T>(key);
        }

        /// <summary>
        /// Filter by condition
        /// </summary>
        /// <param name="selectQuery">select query</param>
        /// <param name="pageNo">Page Size</param>
        /// <param name="pageSize">Page number</param>
        /// <returns></returns>
        public IList<T> FindAll(Expression<Func<T, bool>> selectQuery,
            int pageNo = -1, int pageSize = -1)
        {

            var queryable = this.Context.Set<T>().Where(selectQuery);
            if (pageNo != -1 && pageSize != -1)
            {
                var skipItems = (pageNo - 1) * pageSize;
                queryable = queryable.Skip(skipItems).Take(pageSize);
            }

            return queryable.ToList();
        }
        public IList<T> FindAllReference(Expression<Func<T, bool>> selectQuery,string reference,
         int pageNo = -1, int pageSize = -1)
        {
            IQueryable<T> queryable;
            var references = reference.Split(",");
            if (references.Length > 1)
            {
                queryable = this.Context.Set<T>().Include(references[0]).Include(references[1]).Where(selectQuery);
            }
            else
            {
                queryable = this.Context.Set<T>().Include(references[0]).Where(selectQuery);
            }
           
            if (pageNo != -1 && pageSize != -1)
            {
                var skipItems = (pageNo - 1) * pageSize;
                queryable = queryable.Skip(skipItems).Take(pageSize);
            }
            return queryable.ToList();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> selectQuery)
        {
            var queryable = this.Context.Set<T>().Where(selectQuery);
            return queryable;
        }

        public int Count(Expression<Func<T, bool>> selectQuery)
        {
            var queryable = this.Context.Set<T>().Where(selectQuery);

            return queryable.Count();
        }
    }
}
