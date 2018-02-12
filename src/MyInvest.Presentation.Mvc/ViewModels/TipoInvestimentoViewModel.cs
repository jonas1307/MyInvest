using System;
using System.ComponentModel.DataAnnotations;

namespace MyInvest.Presentation.Mvc.ViewModels
{
    public class TipoInvestimentoViewModel
    {
        [Display(Name = "Código Tipo de Investimento:")]
        public int CodTipoInvestimento { get; set; }

        [Required]
        [Display(Name = "Tipo de Investimento:")]
        [StringLength(150, ErrorMessage = "O nome deve conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Descricao { get; set; }

        [Display(Name = "Data de Cadastro:")]
        public DateTime? DataCadastro { get; set; }
    }
}