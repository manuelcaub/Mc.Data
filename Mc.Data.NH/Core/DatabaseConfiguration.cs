namespace Mc.Data.NH.Core
{
    public class DatabaseConfiguration
    {
        private readonly Database _db;

        public DatabaseConfiguration(Database db, string server, string database, string user, string password)
        {
            _db = db;
            Server = server;
            Database = database;
            User = user;
            Password = password;
        }

        public string ConnectionProvider
        {
            get
            {
                switch (_db)
                {
                    case Core.Database.MySQL:
                    case Core.Database.SQLite:
                    default:
                        return "NHibernate.Connection.DriverConnectionProvider";
                }
            }
        }

        public string Dialect
        {
            get
            {
                switch (_db)
                {
                    case Core.Database.MySQL:
                        return "NHibernate.Dialect.MySQL5Dialect";
                    case Core.Database.SQLite:
                    default:
                        return "NHibernate.Dialect.SQLiteDialect";
                }
            }
        }

        public string ConnectionDriver
        {
            get
            {
                switch (_db)
                {
                    case Core.Database.MySQL:
                        return "NHibernate.Driver.MySqlDataDriver";
                    case Core.Database.SQLite:
                    default:
                        return "NHibernate.Driver.SQLiteDriver";
                }
            }
        }

        public bool FormatSql { get; set; }

        public bool ShowSql { get; set; }

        public string Server { get; }

        public string Database { get; }

        public string User { get; }

        public string Password { get; }

        public bool ConvertZeroDatetime { get; set; } = true;

        public int KeepAlive { get; set; } = 15;

        public int Port { get; set; } = 3306;

        public string ConnectionString
        {
            get
            {
                return $"Server={Server};Port={Port};Database={Database};User ID={User};" +
                    $"Password={Password};Convert Zero Datetime={(ConvertZeroDatetime ? "True" : "False")};" +
                    $"Keep Alive={KeepAlive}";
            }
        }
    }
}
