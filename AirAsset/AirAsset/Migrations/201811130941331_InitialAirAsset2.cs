namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exemplaires", "ExemplaireCount", c => c.Int());
            AddColumn("dbo.Exemplaires", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exemplaires", "Discriminator");
            DropColumn("dbo.Exemplaires", "ExemplaireCount");
        }
    }
}
