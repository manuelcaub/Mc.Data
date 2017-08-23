namespace Mc.Data.NH.Core
{
    using System.Collections.Generic;

    public interface IContextDbFactory
    {
        IContextDb OpenContext();

        IList<string> GetColumnNames<TEntity>();
    }
}
