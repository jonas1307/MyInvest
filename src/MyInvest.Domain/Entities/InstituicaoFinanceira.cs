using System;

namespace MyInvest.Domain.Entities
{
    public class InstituicaoFinanceira
    {
        public long CodInstituicaoFinanceira { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }

        public string CodigoDeCompensacao { get; set; }

        public string HomePage { get; set; }

        public int CodTipoInstituicaoFinanceira { get; set; }

        public virtual TipoInstituicaoFinanceira TipoInstituicaoFinanceira { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}