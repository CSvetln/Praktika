namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incident : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "Employee_EmployeId" });
            AddColumn("dbo.DutyLists", "Employeer_EmployeId", c => c.Int(nullable: false));
            AlterColumn("dbo.ExtremIncidents", "Employee_EmployeId", c => c.Int(nullable: false));
            CreateIndex("dbo.DutyLists", "Employeer_EmployeId");
            CreateIndex("dbo.ExtremIncidents", "Employee_EmployeId");
            AddForeignKey("dbo.DutyLists", "Employeer_EmployeId", "dbo.Employees", "EmployeId", cascadeDelete: true);
            AddForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees", "EmployeId", cascadeDelete: true);
            DropColumn("dbo.DutyLists", "Employee");
            DropColumn("dbo.ExtremIncidents", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExtremIncidents", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.DutyLists", "Employee", c => c.Int(nullable: false));
            DropForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees");
            DropForeignKey("dbo.DutyLists", "Employeer_EmployeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "Employee_EmployeId" });
            DropIndex("dbo.DutyLists", new[] { "Employeer_EmployeId" });
            AlterColumn("dbo.ExtremIncidents", "Employee_EmployeId", c => c.Int());
            DropColumn("dbo.DutyLists", "Employeer_EmployeId");
            CreateIndex("dbo.ExtremIncidents", "Employee_EmployeId");
            AddForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees", "EmployeId");
        }
    }
}
