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
                        Login = c.String(nullable: false),
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
                        Employeer_EmployeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DutyId)
                .ForeignKey("dbo.Employees", t => t.Employeer_EmployeId, cascadeDelete: true)
                .Index(t => t.Employeer_EmployeId);
            
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
                "dbo.Holidays",
                c => new
                    {
                        Holiday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Holiday);
            
            CreateTable(
                "dbo.ExtremIncidents",
                c => new
                    {
                        IncidentId = c.Int(nullable: false, identity: true),
                        DateIncident = c.DateTime(nullable: false),
                        EmployeeEmployeId = c.Int(nullable: false),
                        DecsIncident = c.String(),
                    })
                .PrimaryKey(t => t.IncidentId)
                .ForeignKey("dbo.Employees", t => t.EmployeeEmployeId, cascadeDelete: true)
                .Index(t => t.EmployeeEmployeId);
            
            CreateTable(
                "dbo.Vacations",
                c => new
                    {
                        IdVacation = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Finish = c.DateTime(nullable: false),
                        Employee_EmployeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVacation)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacations", "Employee_EmployeId", "dbo.Employees");
            DropForeignKey("dbo.ExtremIncidents", "EmployeeEmployeId", "dbo.Employees");
            DropForeignKey("dbo.DutyLists", "Employeer_EmployeId", "dbo.Employees");
            DropIndex("dbo.Vacations", new[] { "Employee_EmployeId" });
            DropIndex("dbo.ExtremIncidents", new[] { "EmployeeEmployeId" });
            DropIndex("dbo.DutyLists", new[] { "Employeer_EmployeId" });
            DropTable("dbo.Vacations");
            DropTable("dbo.ExtremIncidents");
            DropTable("dbo.Holidays");
            DropTable("dbo.Employees");
            DropTable("dbo.DutyLists");
            DropTable("dbo.Accesses");
        }
    }
}
