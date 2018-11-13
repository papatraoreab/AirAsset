namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Exemplaires", "ExemplaireCount");
            DropColumn("dbo.Exemplaires", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exemplaires", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Exemplaires", "ExemplaireCount", c => c.Int());
        }
    }
}
