namespace Mc.Data.NH.Dao
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Mc.Data.NH.Core;
    using Mc.Data.NH.Model;

    public class ProductDao
    {
        public T Get<T>(Expression<Func<Product, T>> map)
        {
            using (var session = NHibernateHelper.Instance.ContextFactoryDb.OpenContext())
            {
                return session.Query<Product>().Select(map).FirstOrDefault();
            }
        }

        public bool Any<T>(Expression<Func<Product, bool>> predicate)
        {
            using (var session = NHibernateHelper.Instance.ContextFactoryDb.OpenContext())
            {
                return session.Query<Product>().Any(predicate);
            }
        }

        public void Save<T>(T t)
        {
            using (var session = NHibernateHelper.Instance.ContextFactoryDb.OpenContext())
            {
                session.Save(t);
            }
        }
    }
}
