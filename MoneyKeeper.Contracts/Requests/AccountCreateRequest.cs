
namespace MoneyKeeper.Contracts.Requests
{
    public class AccountCreateRequest
    {
        public string Name { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }
        public decimal InitialValue { get; set; }
        public DateTime Date { get; set; }
    }
}
