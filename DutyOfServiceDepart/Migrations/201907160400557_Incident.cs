namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incident : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExtremIncidents", "DateIncident", c => c.DateTime(nullable: false));
            DropColumn("dbo.ExtremIncidents", "StartIncident");
            DropColumn("dbo.ExtremIncidents", "FinishIncident");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExtremIncidents", "FinishIncident", c => c.DateTime(nullable: false));
            AddColumn("dbo.ExtremIncidents", "StartIncident", c => c.DateTime(nullable: false));
            DropColumn("dbo.ExtremIncidents", "DateIncident");
        }
    }
}
