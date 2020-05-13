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
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DutyId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
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
                        EmployeeEmployeId = c.Int(),
                        DecsIncident = c.String(),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.IncidentId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.Vacations",
                c => new
                    {
                        IdVacation = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Finish = c.DateTime(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVacation)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacations", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ExtremIncidents", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DutyLists", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Vacations", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.ExtremIncidents", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.DutyLists", new[] { "EmployeeId" });
            DropTable("dbo.Vacations");
            DropTable("dbo.ExtremIncidents");
            DropTable("dbo.Holidays");
            DropTable("dbo.Employees");
            DropTable("dbo.DutyLists");
            DropTable("dbo.Accesses");
        }
    }
}
