namespace Xspera.DAL.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Concurrent;
    using System.Data;
    using System.Data.Common;
    using Xspera.DAL.Dao;
    using Xspera.DAL.Entities;
    public class MainRepository : Repository<XsperaContext>, IRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimRepository"/> class.
        /// </summary>
        /// <param name="simDbContext">The sim database context.</param>
        public MainRepository(XsperaContext simDbContext) : base()
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
        /// <summary>
        /// The transaction
        /// </summary>
        private DbTransaction transaction;

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
        protected Repository()
        {
            this.DaoCache = new ConcurrentDictionary<Type, object>();
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
        public DbTransaction BeginTransaction()
        {
            if (null == this.transaction)
            {
                if (this.dbContext.Database.GetDbConnection().State != ConnectionState.Open)
                {
                    this.dbContext.Database.OpenConnection();
                }

                this.transaction = this.dbContext.Database.CurrentTransaction as DbTransaction;
                this.dbContext.Database.UseTransaction(this.transaction);
            }

            return this.transaction;
        }
    }
}