using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyInvest.Presentation.Mvc.ViewModels
{
    public class InstituicaoFinanceiraViewModel
    {
        [Display(Name = "Código")]
        public long CodInstituicaoFinanceira { get; set; }

        [Required]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "Código de Compensação")]
        public string CodigoDeCompensacao { get; set; }

        [Display(Name = "Site")]
        public string HomePage { get; set; }

        [Required]
        [Display(Name = "Tipo de Instituição Financeira")]
        public int CodTipoInstituicaoFinanceira { get; set; }

        public SelectList ListaTipoInstituicaoFinanceira { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}