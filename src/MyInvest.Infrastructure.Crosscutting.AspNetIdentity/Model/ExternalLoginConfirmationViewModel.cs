using System.ComponentModel.DataAnnotations;

namespace MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}