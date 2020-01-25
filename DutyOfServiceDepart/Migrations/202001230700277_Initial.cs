namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExtremIncidents", "EmployeeEmployeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "EmployeeEmployeId" });
            AlterColumn("dbo.ExtremIncidents", "EmployeeEmployeId", c => c.Int());
            CreateIndex("dbo.ExtremIncidents", "EmployeeEmployeId");
            AddForeignKey("dbo.ExtremIncidents", "EmployeeEmployeId", "dbo.Employees", "EmployeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExtremIncidents", "EmployeeEmployeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "EmployeeEmployeId" });
            AlterColumn("dbo.ExtremIncidents", "EmployeeEmployeId", c => c.Int(nullable: true));
            CreateIndex("dbo.ExtremIncidents", "EmployeeEmployeId");
            AddForeignKey("dbo.ExtremIncidents", "EmployeeEmployeId", "dbo.Employees", "EmployeId", cascadeDelete: false);
        }
    }
}
