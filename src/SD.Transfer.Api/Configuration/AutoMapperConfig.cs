using AutoMapper;
using SD.Transfer.Api.ViewModels;
using SD.Transfer.Business.Models;

namespace SD.Transfer.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Conta, ContaViewModel>().ReverseMap();           
            CreateMap<Lancamento, LancamentoViewModel>().ReverseMap();
        }
    }
}