namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        AllowedEdit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccessId);
            
            CreateTable(
                "dbo.DutyLists",
                c => new
                    {
                        DutyId = c.Int(nullable: false, identity: true),
                        DateDuty = c.DateTime(nullable: false),
                        DecrDuty = c.String(),
                        Employee_EmployeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DutyId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.EmployeId);
            
            CreateTable(
                "dbo.ExtremIncidents",
                c => new
                    {
                        IncidentId = c.Int(nullable: false, identity: true),
                        DateIncident = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        DecsIncident = c.String(),
                        Employee_EmployeId = c.Int(),
                    })
                .PrimaryKey(t => t.IncidentId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeId)
                .Index(t => t.Employee_EmployeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExtremIncidents", "Employee_EmployeId", "dbo.Employees");
            DropForeignKey("dbo.DutyLists", "Employee_EmployeId", "dbo.Employees");
            DropIndex("dbo.ExtremIncidents", new[] { "Employee_EmployeId" });
            DropIndex("dbo.DutyLists", new[] { "Employee_EmployeId" });
            DropTable("dbo.ExtremIncidents");
            DropTable("dbo.Employees");
            DropTable("dbo.DutyLists");
            DropTable("dbo.Accesses");
        }
    }
}
