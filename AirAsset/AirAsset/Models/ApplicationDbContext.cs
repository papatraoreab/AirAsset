using Microsoft.AspNet.Identity.EntityFramework;

namespace AirAsset.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AirAsset.Models.Moyen> Moyens { get; set; }

        public System.Data.Entity.DbSet<AirAsset.Models.Exemplaire> Exemplaires { get; set; }

        public System.Data.Entity.DbSet<AirAsset.Models.File> Files { get; set; }
    }
}