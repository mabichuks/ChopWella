namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeReqiredOnBaseEntityNAme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.CheckIns", "Name", c => c.String());
            AlterColumn("dbo.Staffs", "Name", c => c.String());
            AlterColumn("dbo.Vendors", "Name", c => c.String());
            AlterColumn("dbo.Visitors", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visitors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.CheckIns", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
    }
}
