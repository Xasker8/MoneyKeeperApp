using System.ComponentModel.DataAnnotations;

namespace MoneyKeeper.Data.DB.Tables
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 2)]
        public int Type { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
