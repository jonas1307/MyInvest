using System.Data.Entity.ModelConfiguration;
using MyInvest.Domain.Entities;

namespace MyInvest.Infrastructure.Data.EntityConfig
{
    public class TipoInvestimentoConfig : EntityTypeConfiguration<TipoInvestimento>
    {
        public TipoInvestimentoConfig()
        {
            HasKey(pk => pk.CodTipoInvestimento);

            Property(p => p.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.DataCadastro)
                .IsRequired();

            Property(p => p.DataAtualizacao)
                .IsOptional();
        }
    }
}