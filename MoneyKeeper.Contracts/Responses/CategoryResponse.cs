
namespace MoneyKeeper.Contracts.Responses
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
    }
}
