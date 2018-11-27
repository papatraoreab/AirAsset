namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statuts",
                c => new
                    {
                        statutID = c.Int(nullable: false, identity: true),
                        statut = c.String(nullable: false, maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.statutID)
                .Index(t => t.statut, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Statuts", new[] { "statut" });
            DropTable("dbo.Statuts");
        }
    }
}
