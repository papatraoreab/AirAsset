namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Exemplaires", "exemplaireCODE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exemplaires", "exemplaireCODE", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
