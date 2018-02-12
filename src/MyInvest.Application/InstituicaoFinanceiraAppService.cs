using MyInvest.Application.Interfaces;
using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Services;

namespace MyInvest.Application
{
    public class InstituicaoFinanceiraAppService : AppServiceBase<InstituicaoFinanceira>, IInstituicaoFinanceiraAppService
    {
        public InstituicaoFinanceiraAppService(IServiceBase<InstituicaoFinanceira> serviceBase) 
            : base(serviceBase)
        {
        }
    }
}