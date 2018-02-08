using System;

namespace MyInvest.Domain.Entities
{
    public class TipoInstituicaoFinanceira
    {
        public int CodTipoInstituicaoFinanceira { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}