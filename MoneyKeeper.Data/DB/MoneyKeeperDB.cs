using Microsoft.EntityFrameworkCore;
using MoneyKeeper.Data.DB.Tables;

namespace MoneyKeeper.Data.DB
{
    public class MoneyKeeperDB: DbContext
    {
        public MoneyKeeperDB(DbContextOptions<MoneyKeeperDB> option) :
            base(option)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
