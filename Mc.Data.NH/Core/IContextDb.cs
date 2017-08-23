namespace Mc.Data.NH.Core
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Linq;

    public interface IContextDb : IDisposable
    {
        int ExecuteSqlQuery(string query, params Tuple<string, object>[] parameters);

        ITransactionDb BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        IList GetQueryResult(string query);

        IQueryable<TEntity> Query<TEntity>();

        void Save<TEntity>(TEntity entity);

        void SaveOrUpdate<TEntity>(TEntity entity);

        void Update<TEntity>(TEntity entity);

        TEntity Get<TEntity>(object id);

        void Delete<TEntity>(TEntity entity);

        string GetColumnNames(string dbName, string tableName);
    }
}
