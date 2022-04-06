using System.ComponentModel.DataAnnotations;

namespace MoneyKeeper.Data.DB.Tables
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
