namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exemplaires", "moyenID", "dbo.Moyens");
            DropIndex("dbo.Exemplaires", new[] { "moyenID" });
            AddColumn("dbo.Exemplaires", "reference", c => c.String(nullable: false));
            DropColumn("dbo.Exemplaires", "moyenID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exemplaires", "moyenID", c => c.Int(nullable: false));
            DropColumn("dbo.Exemplaires", "reference");
            CreateIndex("dbo.Exemplaires", "moyenID");
            AddForeignKey("dbo.Exemplaires", "moyenID", "dbo.Moyens", "moyenID", cascadeDelete: true);
        }
    }
}
