namespace Xspera.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using Xspera.DAL.Dao;

    /// <summary>
    /// The repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets the DAO.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IDao<TEntity> GetDao<TEntity>() where TEntity : class;

        /// <summary>Executes the query.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        IEnumerable<TResult> ExecuteQuery<TResult>(string query);
        /// <summary>Executes the select list query.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="FetchMethod">The fetch method.</param>
        /// <returns></returns>
        IEnumerable<TResult> ExecuteSelectListQuery<TResult>(string query, int pageNo = 1, int pageSize  = 10, string FetchMethod = "NEXT");
        /// <summary>Executes the multi select query.</summary>
        /// <typeparam name="TFirst">The type of the first.</typeparam>
        /// <typeparam name="Tsecond">The type of the second.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="map">The map.</param>
        /// <param name="splitOn">The split on.</param>
        /// <param name="FetchMethod">The fetch method.</param>
        /// <returns></returns>
        IEnumerable<TResult> ExecuteMultiSelectQuery<TFirst, Tsecond, TResult>(string query, int pageNo, int pageSize , Func<TFirst, Tsecond, TResult> map = null, string splitOn = "Id", string FetchMethod = "NEXT");
    }
}