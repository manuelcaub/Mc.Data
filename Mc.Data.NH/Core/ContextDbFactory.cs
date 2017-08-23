namespace Mc.Data.NH.Core
{
    using System.Collections.Generic;
    using NHibernate;
    using NHibernate.Cfg;

    public class ContextDbFactory : IContextDbFactory
    {
        private ISessionFactory _sessionFactory;

        public ContextDbFactory(Configuration config)
        {
            _sessionFactory = config.BuildSessionFactory();
        }

        public IContextDb OpenContext()
        {
            return new ContextDb(_sessionFactory.OpenSession());
        }

        public IList<string> GetColumnNames<TEntity>()
        {
            global::NHibernate.Metadata.IClassMetadata classMedaData = _sessionFactory.GetClassMetadata(typeof(TEntity));
            IList<string> columnNames = new List<string>(classMedaData.PropertyNames);
            columnNames.Add(classMedaData.IdentifierPropertyName);
            return columnNames;
        }
    }
}
