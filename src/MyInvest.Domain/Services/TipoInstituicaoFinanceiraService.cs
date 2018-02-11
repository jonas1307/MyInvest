using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Repositories;

namespace MyInvest.Domain.Services
{
    public class TipoInstituicaoFinanceiraService : ServiceBase<TipoInstituicaoFinanceira>
    {
        public TipoInstituicaoFinanceiraService(IRepositoryBase<TipoInstituicaoFinanceira> repository) 
            : base(repository)
        { }
    }
}
