namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExtremIncidents", "EmployeeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExtremIncidents", "EmployeeId");
        }
    }
}
