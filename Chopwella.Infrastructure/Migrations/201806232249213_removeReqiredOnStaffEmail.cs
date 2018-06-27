namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeReqiredOnStaffEmail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Staffs", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "Email", c => c.String(nullable: false));
        }
    }
}
