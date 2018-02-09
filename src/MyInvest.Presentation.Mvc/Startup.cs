using Microsoft.Owin;
using MyInvest.Presentation.Mvc;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MyInvest.Presentation.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
