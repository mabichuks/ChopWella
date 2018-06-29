namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequiredOnBaseEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Staffs", "StaffNum", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "Email", c => c.String());
            AlterColumn("dbo.Staffs", "StaffNum", c => c.String());
        }
    }
}
