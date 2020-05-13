namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Holiday : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Holiday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Holiday);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Holidays");
        }
    }
}
