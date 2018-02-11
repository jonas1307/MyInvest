using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Repositories;
using MyInvest.Domain.Interfaces.Services;

namespace MyInvest.Domain.Services
{
    public class TipoInvestimentoService : ServiceBase<TipoInvestimento>, ITipoInvestimentoService
    {
        public TipoInvestimentoService(IRepositoryBase<TipoInvestimento> repository) 
            : base(repository)
        { }
    }
}
