
namespace MoneyKeeper.Contracts.Responses
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }
    }
}
