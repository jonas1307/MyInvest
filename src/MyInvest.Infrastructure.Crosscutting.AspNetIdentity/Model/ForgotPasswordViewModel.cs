﻿using System.ComponentModel.DataAnnotations;

namespace MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
