using System.Collections.Generic;

namespace MoneyKeeper.Data.DB.Tables
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int AccountId { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
