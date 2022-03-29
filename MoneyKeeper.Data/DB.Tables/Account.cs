using System.Collections.Generic;

namespace MoneyKeeper.Data.DB.Tables
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
