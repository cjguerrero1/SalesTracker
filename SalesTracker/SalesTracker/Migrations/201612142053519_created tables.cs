namespace SalesTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        SalesPersonId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.SalesPersons", t => t.SalesPersonId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SalesPersonId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Occupation = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                        SalesPersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.SalesPersons", t => t.SalesPersonId, cascadeDelete: false)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.SalesPersonId);
            
            CreateTable(
                "dbo.SalesPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAddress = c.String(),
                        Zipcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "SalesPersonId", "dbo.SalesPersons");
            DropForeignKey("dbo.Appointments", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Appointments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "SalesPersonId", "dbo.SalesPersons");
            DropForeignKey("dbo.SalesPersons", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Managers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SalesPersons", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Managers", new[] { "ApplicationUserId" });
            DropIndex("dbo.SalesPersons", new[] { "ManagerId" });
            DropIndex("dbo.SalesPersons", new[] { "ApplicationUserId" });
            DropIndex("dbo.Customers", new[] { "SalesPersonId" });
            DropIndex("dbo.Customers", new[] { "ApplicationUserId" });
            DropIndex("dbo.Appointments", new[] { "LocationId" });
            DropIndex("dbo.Appointments", new[] { "SalesPersonId" });
            DropIndex("dbo.Appointments", new[] { "CustomerId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Managers");
            DropTable("dbo.SalesPersons");
            DropTable("dbo.Customers");
            DropTable("dbo.Appointments");
        }
    }
}
