using System;
using Microsoft.AspNet.Identity.EntityFramework;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model;

namespace MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}