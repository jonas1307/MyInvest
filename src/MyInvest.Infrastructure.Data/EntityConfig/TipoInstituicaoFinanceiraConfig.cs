using System.Data.Entity.ModelConfiguration;
using MyInvest.Domain.Entities;

namespace MyInvest.Infrastructure.Data.EntityConfig
{
    public class TipoInstituicaoFinanceiraConfig : EntityTypeConfiguration<TipoInstituicaoFinanceira>
    {
        public TipoInstituicaoFinanceiraConfig()
        {
            HasKey(pk => pk.CodTipoInstituicaoFinanceira);

            Property(p => p.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.DataCadastro)
                .IsRequired();

            Property(p => p.DataAtualizacao)
                .IsOptional();

            HasIndex(idx => idx.Descricao)
                .IsUnique();
        }
    }
}