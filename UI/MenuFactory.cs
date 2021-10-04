using DL;
using RBBL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
            string connectionString = File.ReadAllText(@"../connectionString.txt");

            DbContextOptions<kpopsnapshotdbContext> options = new DbContextOptionsBuilder<kpopsnapshotdbContext>().UseSqlServer(connectionString).Options;

            kpopsnapshotdbContext context = new kpopsnapshotdbContext(options);

            switch (menuString.ToLower())
            {
                case "main":
                    return new MainMenu();
                case "new-customer":
                    return new NewCustomerMenu(new BL(new DBRepo(context)), new NewCustomerService());
                case "customer":
                    return new CustomerMenu(new BL(new DBRepo(context)), new CustomerService());
                case "admin":
                    return new AdminMenu(new BL(new DBRepo(context)), new AdminService());
                default:
                    return null;
            }
        }
    }
}