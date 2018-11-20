namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Moyens", "cmu", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Moyens", "cmu", c => c.Double(nullable: false));
        }
    }
}
