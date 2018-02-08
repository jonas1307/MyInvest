using System;

namespace MyInvest.Domain.Entities
{
    public class TipoInvestimento
    {
        public int CodTipoInvestimento { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
