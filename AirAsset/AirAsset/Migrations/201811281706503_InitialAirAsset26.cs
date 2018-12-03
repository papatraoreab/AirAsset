namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset26 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Exemplaires", "designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exemplaires", "designation", c => c.String(maxLength: 150));
        }
    }
}
