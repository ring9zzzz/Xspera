namespace Xspera.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using Xspera.DAL.Dao;

    /// <summary>
    ///
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets the DAO.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IDao<TEntity> GetDao<TEntity>() where TEntity : class;

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns></returns>
        SqlConnection GetConnection();
        IEnumerable<TResult> ExecuteQuery<TResult>(string query);
        IEnumerable<TResult> ExecuteSelectListQuery<TResult>(string query, int pageNumber = 1, int pageSelect = 10, string FetchMethod = "NEXT");
        IEnumerable<TResult> ExecuteMultiSelectQuery<TFirst, Tsecond, TResult>(string query, int pageNumber, int pageSelect, Func<TFirst, Tsecond, TResult> map = null, string splitOn = "Id", string FetchMethod = "NEXT");
    }
}