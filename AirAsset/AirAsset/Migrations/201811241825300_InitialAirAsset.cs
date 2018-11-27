namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntrepotLignes",
                c => new
                    {
                        entrepotID = c.Int(nullable: false, identity: true),
                        entrepot = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.entrepotID)
                .Index(t => t.entrepot, unique: true);
            
            CreateTable(
                "dbo.Exemplaires",
                c => new
                    {
                        exemplaireID = c.Int(nullable: false, identity: true),
                        moyenID = c.Int(nullable: false),
                        exemplaireCODE = c.String(nullable: false, maxLength: 150),
                        designation = c.String(maxLength: 150),
                        prix = c.Double(nullable: false),
                        suivi = c.String(),
                        location = c.String(),
                        typelocation = c.String(),
                        fournisseur = c.String(nullable: false, maxLength: 150),
                        statut = c.String(),
                        Date_ES = c.DateTime(nullable: false),
                        Date_FS = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.exemplaireID)
                .ForeignKey("dbo.Moyens", t => t.moyenID, cascadeDelete: true)
                .Index(t => t.moyenID);
            
            CreateTable(
                "dbo.Moyens",
                c => new
                    {
                        moyenID = c.Int(nullable: false, identity: true),
                        moyenCODE = c.String(nullable: false, maxLength: 150, unicode: false),
                        designation = c.String(nullable: false, maxLength: 150),
                        quantite = c.Int(nullable: false),
                        secteur = c.String(),
                        program = c.String(),
                        entrepot = c.String(),
                        type = c.String(),
                        description = c.String(nullable: false, maxLength: 250),
                        poids = c.Double(nullable: false),
                        cmu = c.Double(nullable: false),
                        hauteur = c.Double(nullable: false),
                        longueur = c.Double(nullable: false),
                        largeur = c.Double(nullable: false),
                        vVent = c.Double(nullable: false),
                        r_number = c.String(nullable: false),
                        t_number = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.moyenID)
                .Index(t => t.moyenCODE, unique: true);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        fileId = c.Int(nullable: false, identity: true),
                        fileName = c.String(maxLength: 255),
                        contentType = c.String(maxLength: 100),
                        content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        moyenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.fileId)
                .ForeignKey("dbo.Moyens", t => t.moyenID, cascadeDelete: true)
                .Index(t => t.moyenID);
            
            CreateTable(
                "dbo.Exemplaries",
                c => new
                    {
                        exemplaireID = c.Int(nullable: false, identity: true),
                        exemplaireCODE = c.String(nullable: false, maxLength: 150),
                        designation = c.String(maxLength: 150),
                        prix = c.Double(nullable: false),
                        suivi = c.String(),
                        location = c.String(),
                        typelocation = c.String(),
                        fournisseur = c.String(nullable: false, maxLength: 150),
                        statut = c.String(),
                        Date_ES = c.DateTime(nullable: false),
                        Date_FS = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.exemplaireID);
            
            CreateTable(
                "dbo.Programmes",
                c => new
                    {
                        programID = c.Int(nullable: false, identity: true),
                        program = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.programID)
                .Index(t => t.program, unique: true);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Exemplaires", "moyenID", "dbo.Moyens");
            DropForeignKey("dbo.Files", "moyenID", "dbo.Moyens");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Programmes", new[] { "program" });
            DropIndex("dbo.Files", new[] { "moyenID" });
            DropIndex("dbo.Moyens", new[] { "moyenCODE" });
            DropIndex("dbo.Exemplaires", new[] { "moyenID" });
            DropIndex("dbo.EntrepotLignes", new[] { "entrepot" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Programmes");
            DropTable("dbo.Exemplaries");
            DropTable("dbo.Files");
            DropTable("dbo.Moyens");
            DropTable("dbo.Exemplaires");
            DropTable("dbo.EntrepotLignes");
        }
    }
}
