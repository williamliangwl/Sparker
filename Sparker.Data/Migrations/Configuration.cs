namespace Sparker.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sparker.Data.Access.AttendanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Sparker.Data.Access.AttendanceContext";
        }

        protected override void Seed(Sparker.Data.Access.AttendanceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Universities.AddRange(new List<University>()
            {
                new University() { Name="Universitas Bina Nusantara" }
            });
            context.SaveChanges();

            context.Regions.AddRange(new List<Region>()
            {
                new Region() { Name = "Binus" }
            });
        }
    }
}
