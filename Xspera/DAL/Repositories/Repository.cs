namespace Xspera.DAL.Repositories
{
    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Text;
    using Xspera.DAL.Dao;
    using Xspera.DAL.Entities;

    public class MainRepository : Repository<XsperaContext>, IRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimRepository"/> class.
        /// </summary>
        /// <param name="simDbContext">The sim database context.</param>
        public MainRepository(XsperaContext simDbContext, IConfiguration configuration) : base(configuration)
        {
            this.dbContext = simDbContext;
        }
    }

    /// <summary>
    /// Define abtract repository class
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public abstract class Repository<TContext> where TContext : XsperaContext
    {

        private SqlConnection sqlConnection;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The DAO cache
        /// </summary>
        private ConcurrentDictionary<Type, object> DaoCache;

        /// <summary>
        /// The database context
        /// </summary>
        protected TContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TContext}"/> class.
        /// </summary>
        protected Repository(IConfiguration configuration)
        {
            this.DaoCache = new ConcurrentDictionary<Type, object>();
            _configuration = configuration;
            this.sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        /// <summary>
        /// Gets the DAO.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public IDao<TEntity> GetDao<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);
            object result;
            if (!this.DaoCache.TryGetValue(entityType, out result))
            {
                result = new BaseDao<TEntity, TContext>(this.dbContext);
                this.DaoCache.TryAdd(entityType, result);
            }
            else
            {
                result = this.DaoCache[entityType];
            }

            return (IDao<TEntity>)result;
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SqlConnection GetConnection()
        {          
            return this.sqlConnection;
        }
        public IEnumerable<TResult> ExecuteQuery<TResult>(string query)
        {
            sqlConnection.Open();
            try
            {
                return sqlConnection.Query<TResult>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public IEnumerable<TResult> ExecuteSelectListQuery<TResult>(string query, int pageNumber, int pageSelect, string FetchMethod = "NEXT")
        {
            sqlConnection.Open();
            try
            {
                var convertedQuery = new StringBuilder(query);
                if(pageNumber > 0) convertedQuery.AppendLine($"\t OFFSET {((pageNumber - 1) * pageSelect)} ROWS ");
                if(pageSelect > 0) convertedQuery.AppendLine($"\t FETCH {FetchMethod} {pageSelect} ROWS ONLY;");
                return sqlConnection.Query<TResult>(convertedQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public IEnumerable<TResult> ExecuteMultiSelectQuery<TFirst, Tsecond, TResult>(string query, int pageNumber, int pageSelect, Func<TFirst, Tsecond, TResult> map = null,  string splitOn = "Id",  string FetchMethod = "NEXT")
        {
            sqlConnection.Open();
            try
            {
                var convertedQuery = new StringBuilder(query);
                if (pageNumber > 0) convertedQuery.AppendLine($"\t OFFSET {((pageNumber - 1) * pageSelect)} ROWS ");
                if (pageSelect > 0) convertedQuery.AppendLine($"\t FETCH {FetchMethod} {pageSelect} ROWS ONLY;");
                if (map == null)
                {
                    return sqlConnection.Query<TResult>(convertedQuery.ToString());
                }
                else
                {
                    return sqlConnection.Query(convertedQuery.ToString(), map, splitOn: splitOn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}