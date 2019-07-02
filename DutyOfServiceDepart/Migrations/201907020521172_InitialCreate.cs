namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DutyLists",
                c => new
                    {
                        DutyId = c.Int(nullable: false, identity: true),
                        StartDuty = c.DateTime(nullable: false),
                        FinishDuty = c.DateTime(nullable: false),
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
                        FamName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        SecName = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        login = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.EmployeId);
            
            CreateTable(
                "dbo.ExtremIncidents",
                c => new
                    {
                        IncidentId = c.Int(nullable: false, identity: true),
                        StartIncident = c.DateTime(nullable: false),
                        FinishIncident = c.DateTime(nullable: false),
                        DecsIncedent = c.String(),
                        Employee_EmployeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncidentId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeId, cascadeDelete: true)
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
        }
    }
}
