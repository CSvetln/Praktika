namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1607 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DutyLists", "Employee_EmployeId", "dbo.Employees");
            DropForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees");
            RenameColumn(table: "dbo.DutyLists", name: "Employee_EmployeId", newName: "Employee_EmployeeId");
            RenameColumn(table: "dbo.ExtremIncidents", name: "Employee_EmployeId", newName: "EmployeeId");
            RenameIndex(table: "dbo.DutyLists", name: "IX_Employee_EmployeId", newName: "IX_Employee_EmployeeId");
            RenameIndex(table: "dbo.ExtremIncidents", name: "IX_Employee_EmployeId", newName: "IX_EmployeeId");
            DropPrimaryKey("dbo.Employees");
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.DutyLists", "Employee_EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.ExtremIncidents", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            DropColumn("dbo.Employees", "EmployeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ExtremIncidents", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DutyLists", "Employee_EmployeeId", "dbo.Employees");
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "EmployeeId");
            AddPrimaryKey("dbo.Employees", "EmployeId");
            RenameIndex(table: "dbo.ExtremIncidents", name: "IX_EmployeeId", newName: "IX_Employee_EmployeId");
            RenameIndex(table: "dbo.DutyLists", name: "IX_Employee_EmployeeId", newName: "IX_Employee_EmployeId");
            RenameColumn(table: "dbo.ExtremIncidents", name: "EmployeeId", newName: "Employee_EmployeId");
            RenameColumn(table: "dbo.DutyLists", name: "Employee_EmployeeId", newName: "Employee_EmployeId");
            AddForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees", "EmployeId", cascadeDelete: true);
            AddForeignKey("dbo.DutyLists", "Employee_EmployeId", "dbo.Employees", "EmployeId", cascadeDelete: true);
        }
    }
}
