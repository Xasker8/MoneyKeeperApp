using AutoMapper;
using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;
using MoneyKeeper.Data.DB.Tables;

namespace MoneyKeeper.Contracts.AutoMapper
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<AccountCreateRequest, Account>();
            CreateMap<Account, AccountResponse>();

            CreateMap<TransactionCreateRequest, Transaction>();
            CreateMap<Transaction, TransactionResponse>();
        }
    }
}
