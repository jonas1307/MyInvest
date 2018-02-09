using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Configuration;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Context;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model;
using SimpleInjector;

namespace MyInvest.Infrastructure.Crosscutting.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }
    }
}