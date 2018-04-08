using AutoMapper;
using MyInvest.Domain.Entities;
using MyInvest.Presentation.Mvc.ViewModels;

namespace MyInvest.Presentation.Mvc.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<TipoInvestimentoViewModel, TipoInvestimento>();
            CreateMap<TipoInstituicaoFinanceiraViewModel, TipoInstituicaoFinanceira>();
            CreateMap<InstituicaoFinanceiraViewModel, InstituicaoFinanceira>();
        }
    }
}