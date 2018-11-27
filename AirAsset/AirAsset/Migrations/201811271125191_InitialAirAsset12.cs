namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exemplaires", "exemplaireCODE", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exemplaires", "exemplaireCODE");
        }
    }
}
