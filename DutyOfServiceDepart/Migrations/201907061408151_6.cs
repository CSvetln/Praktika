namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FamName", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "SecName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "SecName");
            DropColumn("dbo.Employees", "FamName");
        }
    }
}
