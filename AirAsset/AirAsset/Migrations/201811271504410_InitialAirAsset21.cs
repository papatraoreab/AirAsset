namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exemplaires", "designation", c => c.String(maxLength: 150));
            DropColumn("dbo.Exemplaires", "exemplaireCODE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exemplaires", "exemplaireCODE", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Exemplaires", "designation");
        }
    }
}
