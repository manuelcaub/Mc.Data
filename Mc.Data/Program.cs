namespace Mc.Data
{
    using System;
    using Mc.Data.NH.Core;
    using Mc.Data.NH.Dao;
    using Mc.Data.NH.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            string server, database, user, password;
            try
            {
                server = args[0];
                database = args[1];
                user = args[2];
                password = args[3];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Argumentos incorrectos:\n {ex.ToString()} \n Ej: /nh.exe server database user password");
                Console.ReadLine();
                return;
            }

            try
            {
                NHibernateHelper.Instance.Connect(
                    new DatabaseConfiguration(Database.MySQL, server, database, user, password)
                    {
                        FormatSql = true,
                        ShowSql = true
                    });

                // Ejemplo consultas
                ProductDao dao = new ProductDao();
                dao.Save(new Product { Name = "Hello" });
                dao.Save(new Product { Name = "World" });
                int id = dao.Get(product => product.Id);
                bool exists = dao.Any<Product>(x => x.Id == 1 || x.Name == "World");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                Console.ReadLine();
            }
        }
    }
}
