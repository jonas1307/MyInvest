using Microsoft.AspNet.Identity.EntityFramework;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model;

namespace MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MyInvest", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}