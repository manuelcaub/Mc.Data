namespace Mc.Data.NH.Core
{
    using System;
    using NHibernate.Cfg;

    public class NHibernateHelper
    {
        private static readonly Lazy<NHibernateHelper> _managerDB = new Lazy<NHibernateHelper>(() => new NHibernateHelper());

        private NHibernateHelper()
        {
        }

        public static NHibernateHelper Instance
        {
            get
            {
                return _managerDB.Value;
            }
        }

        public IContextDbFactory ContextFactoryDb { get; set; }

        public void Connect(DatabaseConfiguration config)
        {
            var cfg = GetCfg(config);
            ContextFactoryDb = new ContextDbFactory(cfg);
        }

        private Configuration GetCfg(DatabaseConfiguration config)
        {
            var cfg = new Configuration();
            cfg.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider, config.ConnectionProvider);
            cfg.SetProperty(NHibernate.Cfg.Environment.Dialect, config.Dialect);
            cfg.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, config.ConnectionDriver);
            cfg.SetProperty(NHibernate.Cfg.Environment.FormatSql, config.FormatSql.ToString());
            cfg.SetProperty(NHibernate.Cfg.Environment.ShowSql, config.ShowSql.ToString());
            cfg.SetProperty(NHibernate.Cfg.Environment.ConnectionString, config.ConnectionString);
            cfg.AddAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            // DataAnnotations
            // cfg.AddInputStream(global::NHibernate.Mapping.Attributes.HbmSerializer.Default.Serialize(typeof(Product).Assembly));
            return cfg;
        }
    }
}
