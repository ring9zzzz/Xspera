using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Xspera.DAL.Dao
{
    /// <summary>
    /// Define interface for data access object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public interface IDao<T>
        where T : class
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        object Add(T entity);
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        void AddRange(List<T> entities);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Delete(object key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T Get(object key);

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="selectQuery">The select query.</param>
        /// <param name="pageNo">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        IList<T> FindAll(Expression<Func<T, bool>> selectQuery,
            int pageNo = -1, int pageSize = -1);
        /// <summary>Finds all reference.</summary>
        /// <param name="selectQuery">The select query.</param>
        /// <param name="reference">The reference.</param>
        /// <param name="pageNo">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        IList<T> FindAllReference(Expression<Func<T, bool>> selectQuery, string reference,
         int pageNo = -1, int pageSize = -1);

        /// <summary>Finds the specified select query.</summary>
        /// <param name="selectQuery">The select query.</param>
        /// <returns></returns>
        IQueryable<T> Find(Expression<Func<T, bool>> selectQuery);
        int Count(Expression<Func<T, bool>> selectQuery);
    }
}
