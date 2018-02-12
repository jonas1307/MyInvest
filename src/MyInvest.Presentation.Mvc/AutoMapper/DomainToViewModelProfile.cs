using AutoMapper;
using MyInvest.Domain.Entities;
using MyInvest.Presentation.Mvc.ViewModels;

namespace MyInvest.Presentation.Mvc.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<TipoInvestimento, TipoInvestimentoViewModel>();
            CreateMap<TipoInstituicaoFinanceira, TipoInstituicaoFinanceiraViewModel>();
        }
    }
}