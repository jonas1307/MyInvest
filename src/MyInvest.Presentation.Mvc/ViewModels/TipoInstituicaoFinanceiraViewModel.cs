using System;
using System.ComponentModel.DataAnnotations;

namespace MyInvest.Presentation.Mvc.ViewModels
{
    public class TipoInstituicaoFinanceiraViewModel
    {
        [Display(Name = "Código Tipo de Instituição Financeira:")]
        public int CodTipoInstituicaoFinanceira { get; set; }

        [Required]
        [Display(Name = "Tipo de Instituição:")]
        [StringLength(150, ErrorMessage = "O nome do tipo deve conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Descricao { get; set; }

        [Display(Name = "Data de Cadastro:")]
        public DateTime? DataCadastro { get; set; }
    }
}