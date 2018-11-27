namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Statuts", new[] { "statut" });
            AlterColumn("dbo.Statuts", "statut", c => c.String(nullable: false, maxLength: 10, unicode: false));
            CreateIndex("dbo.Statuts", "statut", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Statuts", new[] { "statut" });
            AlterColumn("dbo.Statuts", "statut", c => c.String(nullable: false, maxLength: 5, unicode: false));
            CreateIndex("dbo.Statuts", "statut", unique: true);
        }
    }
}
