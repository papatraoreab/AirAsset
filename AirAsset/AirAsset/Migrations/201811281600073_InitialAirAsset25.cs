namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset25 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Moyens", new[] { "moyenCODE" });
            AlterColumn("dbo.Moyens", "moyenCODE", c => c.String(nullable: false, maxLength: 6, unicode: false));
            CreateIndex("dbo.Moyens", "moyenCODE", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Moyens", new[] { "moyenCODE" });
            AlterColumn("dbo.Moyens", "moyenCODE", c => c.String(nullable: false, maxLength: 150, unicode: false));
            CreateIndex("dbo.Moyens", "moyenCODE", unique: true);
        }
    }
}
