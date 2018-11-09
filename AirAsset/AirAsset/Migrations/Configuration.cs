namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AirAsset.Models;
    using Microsoft.AspNet.Identity; //added to implement add user and role
    using Microsoft.AspNet.Identity.EntityFramework; // added to implement add user and role

    internal sealed class Configuration : DbMigrationsConfiguration<AirAsset.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AirAsset.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // calling method AddUserAndRole

            AddUserRoleAndRole(context);



        }


        // start added to implement add user and role
        bool AddUserRoleAndRole(AirAsset.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));


            var um = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "advanced_user@airasset.com",//username
               


            };
            ir = um.Create(user, "Advanced*");//passwd

            if(ir.Succeeded == false)
            {
                return ir.Succeeded;
            }
            ir = um.AddToRole(user.Id, "canEdit");
            
            return ir.Succeeded;
        }
        // end added to implement add user and role
    }
}
