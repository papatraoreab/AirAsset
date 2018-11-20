namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Moyens", "r_number", c => c.String(nullable: false));
            AlterColumn("dbo.Moyens", "t_number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Moyens", "t_number", c => c.Int(nullable: false));
            AlterColumn("dbo.Moyens", "r_number", c => c.Int(nullable: false));
        }
    }
}
