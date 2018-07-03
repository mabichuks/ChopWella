namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "StaffNum", c => c.String());
            AddColumn("dbo.Staffs", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Staffs", "StaffId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "StaffId", c => c.String());
            DropColumn("dbo.Staffs", "IsDeleted");
            DropColumn("dbo.Staffs", "StaffNum");
        }
    }
}
