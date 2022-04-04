using Microsoft.EntityFrameworkCore;
using MoneyKeeper.Contracts.Enums;
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
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DefaultCategory> DefaultCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefaultCategory>()
                .HasData(
                new DefaultCategory
                {
                    Id = 1,
                    Name = DefaultCategoryEnum.InitialValue.ToString(),
                    Type = (int)CategoryTypeEnum.Service
                });
        }        
    }
}
