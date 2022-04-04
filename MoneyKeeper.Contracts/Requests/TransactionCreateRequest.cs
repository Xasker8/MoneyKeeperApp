
namespace MoneyKeeper.Contracts.Requests
{
    public class TransactionCreateRequest
    {
        public decimal Sum { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
    }
}
