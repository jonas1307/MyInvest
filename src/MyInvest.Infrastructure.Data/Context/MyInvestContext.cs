using System;
using MyInvest.Domain.Entities;
using MyInvest.Infrastructure.Data.EntityConfig;
using System.Data.Entity;
using System.Linq;

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

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoInstituicaoFinanceira> TiposInstituicoesFinanceiras { get; set; }

        public DbSet<TipoInvestimento> TipoInvestimentos { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new TipoInstituicaoFinanceiraConfig());
            modelBuilder.Configurations.Add(new TipoInvestimentoConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Property("DataCadastro").IsModified = false;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAtualizacao") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAtualizacao").IsModified = true;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        #endregion
    }
}
