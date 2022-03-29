using System.Collections.Generic;

namespace MoneyKeeper.Data.DB.Tables
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
