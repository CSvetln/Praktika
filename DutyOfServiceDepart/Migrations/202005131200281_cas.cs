namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExtremIncidents", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.ExtremIncidents", "EmployeeEmployeId");
            RenameColumn(table: "dbo.ExtremIncidents", name: "Employee_EmployeeId", newName: "EmployeeEmployeId");
            AlterColumn("dbo.ExtremIncidents", "EmployeeEmployeId", c => c.Int(nullable: false));
            AlterColumn("dbo.ExtremIncidents", "EmployeeEmployeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExtremIncidents", "EmployeeEmployeId");
            AddForeignKey("dbo.ExtremIncidents", "EmployeeEmployeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExtremIncidents", "EmployeeEmployeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "EmployeeEmployeId" });
            AlterColumn("dbo.ExtremIncidents", "EmployeeEmployeId", c => c.Int());
            AlterColumn("dbo.ExtremIncidents", "EmployeeEmployeId", c => c.Int());
            RenameColumn(table: "dbo.ExtremIncidents", name: "EmployeeEmployeId", newName: "Employee_EmployeeId");
            AddColumn("dbo.ExtremIncidents", "EmployeeEmployeId", c => c.Int());
            CreateIndex("dbo.ExtremIncidents", "Employee_EmployeeId");
            AddForeignKey("dbo.ExtremIncidents", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
