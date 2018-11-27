namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localisations",
                c => new
                    {
                        localisationId = c.Int(nullable: false, identity: true),
                        localisation = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.localisationId)
                .Index(t => t.localisation, unique: true);
            
            CreateTable(
                "dbo.Secteurs",
                c => new
                    {
                        secteurId = c.Int(nullable: false, identity: true),
                        secteur = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.secteurId)
                .Index(t => t.secteur, unique: true);
            
            AlterColumn("dbo.Suivis", "suivi", c => c.String(nullable: false, maxLength: 50, unicode: false));
            CreateIndex("dbo.Suivis", "suivi", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Suivis", new[] { "suivi" });
            DropIndex("dbo.Secteurs", new[] { "secteur" });
            DropIndex("dbo.Localisations", new[] { "localisation" });
            AlterColumn("dbo.Suivis", "suivi", c => c.String(maxLength: 50));
            DropTable("dbo.Secteurs");
            DropTable("dbo.Localisations");
        }
    }
}
