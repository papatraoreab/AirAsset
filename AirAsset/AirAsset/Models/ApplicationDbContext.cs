using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

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

        public System.Data.Entity.DbSet<AirAsset.Models.Exemplary> Exemplaries { get; set; }
        
        public System.Data.Entity.DbSet<AirAsset.Models.EntrepotLigne> EntrepotLignes { get; set; }

        public System.Data.Entity.DbSet<AirAsset.Models.Programme> Programmes { get; set; }

        public System.Data.Entity.DbSet<AirAsset.Models.Statut> Statuts { get; set; }

        public System.Data.Entity.DbSet<AirAsset.Models.Suivi> Suivis { get; set; }

        public System.Data.Entity.DbSet<AirAsset.Models.Localisation> Localisations { get; set; }

        public System.Data.Entity.DbSet<AirAsset.Models.Secteur> Secteurs { get; set; }

        public System.Data.Entity.DbSet<AirAsset.Models.TypeLocalisation> TypeLocalisations { get; set; }

        public System.Data.Entity.DbSet<AirAsset.Models.TypeMoyen> TypeMoyens { get; set; }
    }
}