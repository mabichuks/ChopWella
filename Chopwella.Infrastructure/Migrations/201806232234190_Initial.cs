namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffId = c.Int(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        VendorId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffId = c.String(),
                        Email = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitors", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.CheckIns", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.CheckIns", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Visitors", new[] { "StaffId" });
            DropIndex("dbo.Staffs", new[] { "CategoryId" });
            DropIndex("dbo.CheckIns", new[] { "VendorId" });
            DropIndex("dbo.CheckIns", new[] { "StaffId" });
            DropTable("dbo.Visitors");
            DropTable("dbo.Vendors");
            DropTable("dbo.Staffs");
            DropTable("dbo.CheckIns");
            DropTable("dbo.Categories");
        }
    }
}
