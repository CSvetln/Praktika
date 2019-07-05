namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _111 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        LevelAccess = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Login);
            
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        CurrentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CurrentDate);
            
            AddColumn("dbo.ExtremIncidents", "DecsIncident", c => c.String());
            AlterColumn("dbo.Employees", "Login", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.ExtremIncidents", "DecsIncedent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExtremIncidents", "DecsIncedent", c => c.String());
            AlterColumn("dbo.Employees", "Login", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.ExtremIncidents", "DecsIncident");
            DropTable("dbo.Calendars");
            DropTable("dbo.Accesses");
        }
    }
}
