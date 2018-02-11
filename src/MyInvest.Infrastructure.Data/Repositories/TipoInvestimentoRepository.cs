using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Repositories;

namespace MyInvest.Infrastructure.Data.Repositories
{
    public class TipoInvestimentoRepository : RepositoryBase<TipoInvestimento>, ITipoInvestimentoRepository
    { }
}