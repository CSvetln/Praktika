namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DutyLists", "DateDuty", c => c.DateTime(nullable: false));
            DropColumn("dbo.DutyLists", "StartDuty");
            DropColumn("dbo.DutyLists", "FinishDuty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DutyLists", "FinishDuty", c => c.DateTime(nullable: false));
            AddColumn("dbo.DutyLists", "StartDuty", c => c.DateTime(nullable: false));
            DropColumn("dbo.DutyLists", "DateDuty");
        }
    }
}
