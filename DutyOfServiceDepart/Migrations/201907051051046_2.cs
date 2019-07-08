namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Calendars");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        CurrentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CurrentDate);
            
        }
    }
}
