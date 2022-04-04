
namespace MoneyKeeper.Data.DB.Tables
{
    public class Category
    {
        public int Id { get; set; }
        //TODO: Уникальное имя и тип (вместе)
        public string Name { get; set; }
        public int Type { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
