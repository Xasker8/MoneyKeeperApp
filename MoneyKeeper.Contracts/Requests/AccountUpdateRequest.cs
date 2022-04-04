
namespace MoneyKeeper.Contracts.Requests
{
    public class AccountUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrencyId { get; set; }
    }
}
