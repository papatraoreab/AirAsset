namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suivis",
                c => new
                    {
                        suiviID = c.Int(nullable: false, identity: true),
                        suivi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.suiviID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suivis");
        }
    }
}
