using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Repositories;
using MyInvest.Domain.Interfaces.Services;

namespace MyInvest.Domain.Services
{
    public class TipoInstituicaoFinanceiraService : ServiceBase<TipoInstituicaoFinanceira>, ITipoInstituicaoFinanceiraService
    {
        public TipoInstituicaoFinanceiraService(IRepositoryBase<TipoInstituicaoFinanceira> repository) 
            : base(repository)
        { }
    }
}
