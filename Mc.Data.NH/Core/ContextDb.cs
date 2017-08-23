namespace Mc.Data.NH.Core
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Linq;
    using NHibernate;
    using NHibernate.Linq;

    public class ContextDb : IContextDb
    {
        private ISession _session;

        public ContextDb(ISession session)
        {
            _session = session;
        }

        public IQueryable<TEntity> Query<TEntity>()
        {
            return _session.Query<TEntity>();
        }

        public void Save<TEntity>(TEntity entity)
        {
            _session.Save(entity);
        }

        public ITransactionDb BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return new TransactionDb(_session.BeginTransaction(isolationLevel));
        }

        public IList GetQueryResult(string query)
        {
            return _session.CreateSQLQuery(query).List();
        }

        public void Update<TEntity>(TEntity entity)
        {
            _session.Update(entity);
        }

        public TEntity Get<TEntity>(object id)
        {
            return _session.Get<TEntity>(id);
        }

        public void Delete<TEntity>(TEntity entity)
        {
            _session.Delete(entity);
        }

        public int ExecuteSqlQuery(string query, params System.Tuple<string, object>[] parameters)
        {
            IQuery sqlQuery = _session.CreateSQLQuery(query);
            foreach (var parameter in parameters)
            {
                sqlQuery = sqlQuery.SetParameter(parameter.Item1, parameter.Item2);
            }

            return sqlQuery.ExecuteUpdate();
        }

        public IList ListSqlQuery(string query, params System.Tuple<string, object>[] parameters)
        {
            IQuery sqlQuery = _session.CreateSQLQuery(query);
            foreach (var parameter in parameters)
            {
                sqlQuery = sqlQuery.SetParameter(parameter.Item1, parameter.Item2);
            }

            return sqlQuery.List();
        }

        public void SaveOrUpdate<TEntity>(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public string GetColumnNames(string dbName, string tableName)
        {
            string query = "select group_concat(column_name order by ordinal_position) from information_schema.columns where table_schema = :dbName and table_name = :tableName; ";
            return ListSqlQuery(query, new System.Tuple<string, object>("dbName", dbName), new System.Tuple<string, object>("tableName", tableName)).Cast<string>().FirstOrDefault();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_session != null)
                {
                    _session.Dispose();
                    _session = null;
                }
            }
        }
    }
}