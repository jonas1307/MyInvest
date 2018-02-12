using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model;

namespace MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Configuration
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            // Account Lockout
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            // 2FA SMS
            RegisterTwoFactorProvider("Código via SMS", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Seu código de segurança é: {0}"
            });

            // 2FA E-mail
            RegisterTwoFactorProvider("Código via E-mail", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Código de Segurança",
                BodyFormat = "Seu código de segurança é: {0}"
            });

            // Definindo a classe de serviço de e-mail
            EmailService = new EmailService();

            // Definindo a classe de serviço de SMS
            SmsService = new SmsService();

            var provider = new DpapiDataProtectionProvider("MyInvestApplication");
            var dataProtector = provider.Create("ASP.NET Identity");

            UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtector);
        }
    }
}