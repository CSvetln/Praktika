namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateduty : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ExtremIncidents", name: "Employee_EmployeId", newName: "EmployeeEmployeId");
            RenameIndex(table: "dbo.ExtremIncidents", name: "IX_Employee_EmployeId", newName: "IX_EmployeeEmployeId");
            DropColumn("dbo.DutyLists", "DecrDuty");
            DropColumn("dbo.ExtremIncidents", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExtremIncidents", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.DutyLists", "DecrDuty", c => c.String());
            RenameIndex(table: "dbo.ExtremIncidents", name: "IX_EmployeeEmployeId", newName: "IX_Employee_EmployeId");
            RenameColumn(table: "dbo.ExtremIncidents", name: "EmployeeEmployeId", newName: "Employee_EmployeId");
        }
    }
}
