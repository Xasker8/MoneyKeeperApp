using System.ComponentModel.DataAnnotations;

namespace MoneyKeeper.Data.DB.Tables
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //TODO: unique
        public string Name { get; set; }
        [Required]
        //TODO: unique
        public string ShortName { get; set; }
        [Required]
        public string Icon { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
