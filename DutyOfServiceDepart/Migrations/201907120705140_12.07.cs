namespace DutyOfServiceDepart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1207 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accesses", "AllowedEdit", c => c.Boolean(nullable: false));
            DropColumn("dbo.Accesses", "LevelAccess");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accesses", "LevelAccess", c => c.Int(nullable: false));
            DropColumn("dbo.Accesses", "AllowedEdit");
        }
    }
}
