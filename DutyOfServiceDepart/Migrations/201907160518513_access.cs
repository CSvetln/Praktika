namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class access : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Accesses");
            AddColumn("dbo.Accesses", "AccessId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Accesses", "Login", c => c.String());
            AddPrimaryKey("dbo.Accesses", "AccessId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Accesses");
            AlterColumn("dbo.Accesses", "Login", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Accesses", "AccessId");
            AddPrimaryKey("dbo.Accesses", "Login");
        }
    }
}
