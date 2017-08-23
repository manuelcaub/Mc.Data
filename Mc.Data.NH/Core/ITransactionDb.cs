namespace Mc.Data.NH.Core
{
    using System;

    public interface ITransactionDb : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
