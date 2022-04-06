using System.ComponentModel.DataAnnotations;

namespace MoneyKeeper.Data.DB.Tables
{
    public class DefaultCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //TODO: unique
        public string Name { get; set; }
        [Required]
        [Range(0, 2)]
        public int Type { get; set; }
    }
}
