using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyInvest.Application;
using MyInvest.Application.Interfaces;
using MyInvest.Domain.Interfaces.Repositories;
using MyInvest.Domain.Interfaces.Services;
using MyInvest.Domain.Services;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Configuration;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Context;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model;
using MyInvest.Infrastructure.Data.Repositories;
using SimpleInjector;

namespace MyInvest.Infrastructure.Crosscutting.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(Container container)
        {
            // Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            // App Services
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), Lifestyle.Scoped);
            container.Register<ITipoInvestimentoAppService, TipoInvestimentoAppService>(Lifestyle.Scoped);
            container.Register<ITipoInstituicaoFinanceiraAppService, TipoInstituicaoFinanceiraAppService>(Lifestyle.Scoped);
            container.Register<IInstituicaoFinanceiraAppService, InstituicaoFinanceiraAppService>(Lifestyle.Scoped);

            // Services
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            container.Register<ITipoInvestimentoService, TipoInvestimentoService>(Lifestyle.Scoped);
            container.Register<ITipoInstituicaoFinanceiraService, TipoInstituicaoFinanceiraService>(Lifestyle.Scoped);
            container.Register<IInstituicaoFinanceiraService, InstituicaoFinanceiraService>(Lifestyle.Scoped);

            // Repositories
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register<ITipoInvestimentoRepository, TipoInvestimentoRepository>(Lifestyle.Scoped);
            container.Register<ITipoInstituicaoFinanceiraRepository, TipoInstituicaoFinanceiraRepository>(Lifestyle.Scoped);
            container.Register<IInstituicaoFinanceiraRepository, InstituicaoFinanceiraRepository>(Lifestyle.Scoped);
        }
    }
}