namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exemplaires", "Moyen_moyenID", c => c.Int());
            CreateIndex("dbo.Exemplaires", "Moyen_moyenID");
            AddForeignKey("dbo.Exemplaires", "Moyen_moyenID", "dbo.Moyens", "moyenID");
            DropColumn("dbo.Exemplaires", "designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exemplaires", "designation", c => c.String(maxLength: 150));
            DropForeignKey("dbo.Exemplaires", "Moyen_moyenID", "dbo.Moyens");
            DropIndex("dbo.Exemplaires", new[] { "Moyen_moyenID" });
            DropColumn("dbo.Exemplaires", "Moyen_moyenID");
        }
    }
}
