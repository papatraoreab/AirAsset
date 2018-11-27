namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Programmes", new[] { "program" });
            DropIndex("dbo.Statuts", new[] { "statut" });
            AlterColumn("dbo.Programmes", "program", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Statuts", "statut", c => c.String(nullable: false, maxLength: 50, unicode: false));
            CreateIndex("dbo.Programmes", "program", unique: true);
            CreateIndex("dbo.Statuts", "statut", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Statuts", new[] { "statut" });
            DropIndex("dbo.Programmes", new[] { "program" });
            AlterColumn("dbo.Statuts", "statut", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Programmes", "program", c => c.String(nullable: false, maxLength: 150, unicode: false));
            CreateIndex("dbo.Statuts", "statut", unique: true);
            CreateIndex("dbo.Programmes", "program", unique: true);
        }
    }
}
