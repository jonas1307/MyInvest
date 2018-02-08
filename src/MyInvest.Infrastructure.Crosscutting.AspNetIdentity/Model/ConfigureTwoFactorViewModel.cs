using System.Collections.Generic;

namespace MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<string> Providers { get; set; }
    }
}