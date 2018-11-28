namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset17 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Assets", "designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assets", "designation", c => c.String(maxLength: 150));
        }
    }
}
