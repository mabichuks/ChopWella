namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompleteDeleteFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Staffs", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
