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
    //public class DomainProfile : Profile
    //{
    //    public DomainProfile()
    //    {
    //        CreateMaps();
    //    }

    //    public void CreateMaps()
    //    {
    //        CreateMap<CanvasModelRequest, CanvasRequest>();
    //        //File Mappings
    //        CreateMap<FileContractResponse, File>();
    //        CreateMap<File, FileContractResponse>();
    //        CreateMap<File, ProjectFileInfoResponse>();
    //        CreateMap<FileItemResponse, File>();
    //        CreateMap<File, FileItemResponse>();
    //        CreateMap<File, FileContractRequest>();
    //        CreateMap<FileContractRequest, File>();
    //        //Project Mappings
    //        CreateMap<Project, ProjectContractRequest>();
    //        CreateMap<ProjectContractRequest, Project>();
    //        CreateMap<Project, ProjectContractResponse>()
    //            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.MiddlewareId));
    //        CreateMap<ProjectContractResponse, Project>();
    //        CreateMap<ProjectContractRequest, ProjectContractResponse>();
    //        CreateMap<ProjectContractResponse, ProjectContractRequest>();
    //        CreateMap<List<ProjectOutputContractResponse>, List<Project>>();
    //        CreateMap<Project, ProjectItemResponseContract>()
    //            .ForMember(dest => dest.GroupIds, opt =>
    //            opt.MapFrom(src => src.GroupIds.Select(x => x.GroupId).ToArray<string>()));
    //        CreateMap<Payload, PayloadResponse>();
    //        CreateMap<Payload, AllPayloadsResponse>();
    //    }
    //}
}
