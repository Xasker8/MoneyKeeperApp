using System.ComponentModel.DataAnnotations;

namespace MoneyKeeper.Data.DB.Tables
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Sum { get; set; }
        public string Comment { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
