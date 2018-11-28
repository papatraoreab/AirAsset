namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset14 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EntrepotLignes", new[] { "entrepot" });
            DropIndex("dbo.Localisations", new[] { "localisation" });
            DropIndex("dbo.Programmes", new[] { "program" });
            DropIndex("dbo.Secteurs", new[] { "secteur" });
            DropIndex("dbo.Statuts", new[] { "statut" });
            DropIndex("dbo.Suivis", new[] { "suivi" });
            DropIndex("dbo.TypeLocalisations", new[] { "typelocalisation" });
            DropIndex("dbo.TypeMoyens", new[] { "typemoyen" });
            DropTable("dbo.EntrepotLignes");
            DropTable("dbo.Exemplaries");
            DropTable("dbo.Localisations");
            DropTable("dbo.Programmes");
            DropTable("dbo.Secteurs");
            DropTable("dbo.Statuts");
            DropTable("dbo.Suivis");
            DropTable("dbo.TypeLocalisations");
            DropTable("dbo.TypeMoyens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TypeMoyens",
                c => new
                    {
                        typemoyenID = c.Int(nullable: false, identity: true),
                        typemoyen = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.typemoyenID);
            
            CreateTable(
                "dbo.TypeLocalisations",
                c => new
                    {
                        typelocalisationId = c.Int(nullable: false, identity: true),
                        typelocalisation = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.typelocalisationId);
            
            CreateTable(
                "dbo.Suivis",
                c => new
                    {
                        suiviID = c.Int(nullable: false, identity: true),
                        suivi = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.suiviID);
            
            CreateTable(
                "dbo.Statuts",
                c => new
                    {
                        statutID = c.Int(nullable: false, identity: true),
                        statut = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.statutID);
            
            CreateTable(
                "dbo.Secteurs",
                c => new
                    {
                        secteurId = c.Int(nullable: false, identity: true),
                        secteur = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.secteurId);
            
            CreateTable(
                "dbo.Programmes",
                c => new
                    {
                        programID = c.Int(nullable: false, identity: true),
                        program = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.programID);
            
            CreateTable(
                "dbo.Localisations",
                c => new
                    {
                        localisationId = c.Int(nullable: false, identity: true),
                        localisation = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.localisationId);
            
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
                "dbo.EntrepotLignes",
                c => new
                    {
                        entrepotID = c.Int(nullable: false, identity: true),
                        entrepot = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.entrepotID);
            
            CreateIndex("dbo.TypeMoyens", "typemoyen", unique: true);
            CreateIndex("dbo.TypeLocalisations", "typelocalisation", unique: true);
            CreateIndex("dbo.Suivis", "suivi", unique: true);
            CreateIndex("dbo.Statuts", "statut", unique: true);
            CreateIndex("dbo.Secteurs", "secteur", unique: true);
            CreateIndex("dbo.Programmes", "program", unique: true);
            CreateIndex("dbo.Localisations", "localisation", unique: true);
            CreateIndex("dbo.EntrepotLignes", "entrepot", unique: true);
        }
    }
}
