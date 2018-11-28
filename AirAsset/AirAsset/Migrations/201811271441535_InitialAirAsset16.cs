namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "exemplaireCODE", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Assets", "designation", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "designation");
            DropColumn("dbo.Assets", "exemplaireCODE");
        }
    }
}
