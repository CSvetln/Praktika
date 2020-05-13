namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dutyemp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExtremIncidents", "EmployeeEmployeId", "dbo.Employees");
            DropForeignKey("dbo.DutyLists", "EmployeeEmployeId", "dbo.Employees");
            DropForeignKey("dbo.Vacations", "Employee_EmployeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "EmployeeEmployeId" });
            RenameColumn(table: "dbo.DutyLists", name: "EmployeeEmployeId", newName: "EmployeeId");
            RenameColumn(table: "dbo.Vacations", name: "Employee_EmployeId", newName: "Employee_EmployeeId");
            RenameIndex(table: "dbo.DutyLists", name: "IX_EmployeeEmployeId", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.Vacations", name: "IX_Employee_EmployeId", newName: "IX_Employee_EmployeeId");
            DropPrimaryKey("dbo.Employees");
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ExtremIncidents", "Employee_EmployeeId", c => c.Int());
            AddPrimaryKey("dbo.Employees", "EmployeeId");
            CreateIndex("dbo.ExtremIncidents", "Employee_EmployeeId");
            AddForeignKey("dbo.ExtremIncidents", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.DutyLists", "EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Vacations", "Employee_EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            DropColumn("dbo.Employees", "EmployeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Vacations", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DutyLists", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ExtremIncidents", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "Employee_EmployeeId" });
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.ExtremIncidents", "Employee_EmployeeId");
            DropColumn("dbo.Employees", "EmployeeId");
            AddPrimaryKey("dbo.Employees", "EmployeId");
            RenameIndex(table: "dbo.Vacations", name: "IX_Employee_EmployeeId", newName: "IX_Employee_EmployeId");
            RenameIndex(table: "dbo.DutyLists", name: "IX_EmployeeId", newName: "IX_EmployeeEmployeId");
            RenameColumn(table: "dbo.Vacations", name: "Employee_EmployeeId", newName: "Employee_EmployeId");
            RenameColumn(table: "dbo.DutyLists", name: "EmployeeId", newName: "EmployeeEmployeId");
            CreateIndex("dbo.ExtremIncidents", "EmployeeEmployeId");
            AddForeignKey("dbo.Vacations", "Employee_EmployeId", "dbo.Employees", "EmployeId", cascadeDelete: true);
            AddForeignKey("dbo.DutyLists", "EmployeeEmployeId", "dbo.Employees", "EmployeId");
            AddForeignKey("dbo.ExtremIncidents", "EmployeeEmployeId", "dbo.Employees", "EmployeId");
        }
    }
}
