namespace Xspera.DAL.Repositories
{
    using System.Data.Common;
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
        DbTransaction BeginTransaction();
    }
}