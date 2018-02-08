using System.ComponentModel.DataAnnotations;

namespace MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}