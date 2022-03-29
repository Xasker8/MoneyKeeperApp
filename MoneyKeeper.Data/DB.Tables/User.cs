using System.Collections.Generic;

namespace MoneyKeeper.Data.DB.Tables
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
