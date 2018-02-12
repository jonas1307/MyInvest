using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Repositories;
using MyInvest.Domain.Interfaces.Services;

namespace MyInvest.Domain.Services
{
    public class InstituicaoFinanceiraService : ServiceBase<InstituicaoFinanceira>, IInstituicaoFinanceiraService
    {
        public InstituicaoFinanceiraService(IRepositoryBase<InstituicaoFinanceira> repository) 
            : base(repository)
        {
        }
    }
}
