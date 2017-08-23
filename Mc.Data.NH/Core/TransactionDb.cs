namespace Mc.Data.NH.Core
{
    using System;
    using NHibernate;

    public class TransactionDb : ITransactionDb
    {
        private ITransaction _transaction;

        public TransactionDb(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
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
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }
    }
}
