namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Exemplaires", new[] { "exemplaireCODE" });
            AlterColumn("dbo.Exemplaires", "exemplaireCODE", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exemplaires", "exemplaireCODE", c => c.String(nullable: false, maxLength: 150, unicode: false));
            CreateIndex("dbo.Exemplaires", "exemplaireCODE", unique: true);
        }
    }
}
