namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vacation : DbMigration
    {
        public override void Up()
        {
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
            
            AlterColumn("dbo.Accesses", "Login", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacations", "Employee_EmployeId", "dbo.Employees");
            DropIndex("dbo.Vacations", new[] { "Employee_EmployeId" });
            AlterColumn("dbo.Accesses", "Login", c => c.String());
            DropTable("dbo.Vacations");
        }
    }
}
