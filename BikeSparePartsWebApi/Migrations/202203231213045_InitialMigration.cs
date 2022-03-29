namespace BikeSparePartsWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BikeSpareParts",
                c => new
                    {
                        SparePartID = c.Int(nullable: false, identity: true),
                        SparePartName = c.String(maxLength: 30),
                        SparePartPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SparePartID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BikeSpareParts");
        }
    }
}
