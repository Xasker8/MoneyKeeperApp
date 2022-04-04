
namespace MoneyKeeper.Contracts.Requests
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
    }
}
