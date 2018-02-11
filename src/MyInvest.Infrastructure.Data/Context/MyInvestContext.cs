using MyInvest.Domain.Entities;
using MyInvest.Infrastructure.Data.EntityConfig;
using System.Data.Entity;

namespace MyInvest.Infrastructure.Data.Context
{
    public class MyInvestContext : DbContext
    {
        #region Constructors

        public MyInvestContext()
            : base("MyInvest")
        { }

        #endregion

        #region Properties

        DbSet<Usuario> Usuarios { get; set; }

        private DbSet<TipoInstituicaoFinanceira> TiposInstituicoesFinanceiras { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new TipoInstituicaoFinanceiraConfig());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
