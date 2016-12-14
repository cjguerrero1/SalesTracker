namespace SalesTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmorecustomerinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Chest = c.Int(nullable: false),
                        OverArm = c.Int(nullable: false),
                        Waist = c.Int(nullable: false),
                        Hip = c.Int(nullable: false),
                        Outseam = c.Int(nullable: false),
                        Neck = c.Int(nullable: false),
                        ShirtSleeve = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JacketSize = c.String(),
                        PantSize = c.String(),
                        DressShirtSize = c.String(),
                        CasualSize = c.String(),
                        ShoeSize = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MeasurementsId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "SizesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MeasurementsId");
            CreateIndex("dbo.Customers", "SizesId");
            AddForeignKey("dbo.Customers", "MeasurementsId", "dbo.Measurements", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "SizesId", "dbo.Sizes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "SizesId", "dbo.Sizes");
            DropForeignKey("dbo.Customers", "MeasurementsId", "dbo.Measurements");
            DropIndex("dbo.Customers", new[] { "SizesId" });
            DropIndex("dbo.Customers", new[] { "MeasurementsId" });
            DropColumn("dbo.Customers", "SizesId");
            DropColumn("dbo.Customers", "MeasurementsId");
            DropTable("dbo.Sizes");
            DropTable("dbo.Measurements");
        }
    }
}
