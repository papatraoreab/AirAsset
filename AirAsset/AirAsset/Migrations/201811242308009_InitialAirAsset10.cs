namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeMoyens",
                c => new
                    {
                        typemoyenID = c.Int(nullable: false, identity: true),
                        typemoyen = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.typemoyenID)
                .Index(t => t.typemoyen, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TypeMoyens", new[] { "typemoyen" });
            DropTable("dbo.TypeMoyens");
        }
    }
}
