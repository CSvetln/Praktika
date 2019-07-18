namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1807 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "Employee_EmployeId" });
            AlterColumn("dbo.ExtremIncidents", "Employee_EmployeId", c => c.Int());
            CreateIndex("dbo.ExtremIncidents", "Employee_EmployeId");
            AddForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees", "EmployeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "Employee_EmployeId" });
            AlterColumn("dbo.ExtremIncidents", "Employee_EmployeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExtremIncidents", "Employee_EmployeId");
            AddForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees", "EmployeId", cascadeDelete: true);
        }
    }
}
