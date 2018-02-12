using System.Data.Entity.ModelConfiguration;
using MyInvest.Domain.Entities;

namespace MyInvest.Infrastructure.Data.EntityConfig
{
    public class InstituicaoFinanceiraConfig : EntityTypeConfiguration<InstituicaoFinanceira>
    {
        public InstituicaoFinanceiraConfig()
        {
            HasKey(pk => pk.CodInstituicaoFinanceira);

            Property(p => p.RazaoSocial)
                .IsRequired();

            Property(p => p.NomeFantasia)
                .IsRequired();

            Property(p => p.Cnpj)
                .HasMaxLength(14)
                .IsRequired();

            Property(p => p.CodigoDeCompensacao)
                .HasMaxLength(6)
                .IsOptional();

            Property(p => p.HomePage)
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.CodTipoInstituicaoFinanceira)
                .IsRequired();

            Property(p => p.DataCadastro)
                .IsRequired();

            Property(p => p.DataAtualizacao)
                .IsOptional();

            HasRequired(fk => fk.TipoInstituicaoFinanceira)
                .WithMany()
                .HasForeignKey(fk => fk.CodTipoInstituicaoFinanceira);

            HasIndex(idx => idx.CodigoDeCompensacao)
                .IsUnique();

            HasIndex(idx => idx.Cnpj)
                .IsUnique();
        }
    }
}