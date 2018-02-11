using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Repositories;

namespace MyInvest.Domain.Services
{
    public class TipoInvestimentoService : ServiceBase<TipoInvestimento>
    {
        public TipoInvestimentoService(IRepositoryBase<TipoInvestimento> repository) 
            : base(repository)
        { }
    }
}
