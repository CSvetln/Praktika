namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dutylists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DutyLists", "Employee_EmployeId", "dbo.Employees");
            DropIndex("dbo.DutyLists", new[] { "Employee_EmployeId" });
            AddColumn("dbo.DutyLists", "Employee", c => c.Int(nullable: false));
            DropColumn("dbo.DutyLists", "Employee_EmployeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DutyLists", "Employee_EmployeId", c => c.Int(nullable: false));
            DropColumn("dbo.DutyLists", "Employee");
            CreateIndex("dbo.DutyLists", "Employee_EmployeId");
            AddForeignKey("dbo.DutyLists", "Employee_EmployeId", "dbo.Employees", "EmployeId", cascadeDelete: true);
        }
    }
}
