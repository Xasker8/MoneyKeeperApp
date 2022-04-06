using System.ComponentModel.DataAnnotations;

namespace MoneyKeeper.Data.DB.Tables
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //TODO: unique for user
        public string Name { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;

        [Required]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
