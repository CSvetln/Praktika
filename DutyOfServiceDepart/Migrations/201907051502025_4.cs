namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "FamName");
            DropColumn("dbo.Employees", "SecName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "SecName", c => c.String());
            AddColumn("dbo.Employees", "FamName", c => c.String(nullable: false));
        }
    }
}
