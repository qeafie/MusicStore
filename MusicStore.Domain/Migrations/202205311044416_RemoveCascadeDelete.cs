namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCascadeDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instruments", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instruments", "IsDeleted");
        }
    }
}
