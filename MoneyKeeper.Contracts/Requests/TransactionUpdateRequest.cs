
namespace MoneyKeeper.Contracts.Requests
{
    public class TransactionUpdateRequest
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
    }
}
