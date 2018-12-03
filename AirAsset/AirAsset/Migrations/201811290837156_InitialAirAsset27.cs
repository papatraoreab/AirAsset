namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exemplaires", "designation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exemplaires", "designation");
        }
    }
}
