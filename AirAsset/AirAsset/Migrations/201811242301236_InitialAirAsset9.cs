namespace AirAsset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirAsset9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeLocalisations",
                c => new
                    {
                        typelocalisationId = c.Int(nullable: false, identity: true),
                        typelocalisation = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.typelocalisationId)
                .Index(t => t.typelocalisation, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TypeLocalisations", new[] { "typelocalisation" });
            DropTable("dbo.TypeLocalisations");
        }
    }
}
