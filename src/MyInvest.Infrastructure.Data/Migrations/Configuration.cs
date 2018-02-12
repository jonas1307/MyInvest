using System.Data.Entity.Migrations;
using MyInvest.Infrastructure.Data.Context;

namespace MyInvest.Infrastructure.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyInvestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyInvestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
