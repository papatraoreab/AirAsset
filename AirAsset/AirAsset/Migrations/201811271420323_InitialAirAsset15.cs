namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        assetID = c.Int(nullable: false, identity: true),
                        reference = c.String(nullable: false),
                        prix = c.Double(nullable: false),
                        suivi = c.String(),
                        location = c.String(),
                        typelocation = c.String(),
                        fournisseur = c.String(nullable: false, maxLength: 150),
                        statut = c.String(),
                        moyen_moyenID = c.Int(),
                    })
                .PrimaryKey(t => t.assetID)
                .ForeignKey("dbo.Moyens", t => t.moyen_moyenID)
                .Index(t => t.moyen_moyenID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "moyen_moyenID", "dbo.Moyens");
            DropIndex("dbo.Assets", new[] { "moyen_moyenID" });
            DropTable("dbo.Assets");
        }
    }
}
