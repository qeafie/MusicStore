namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instruments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Instruments", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Instruments", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instruments", "Category", c => c.String());
            AlterColumn("dbo.Instruments", "Description", c => c.String());
            AlterColumn("dbo.Instruments", "Name", c => c.String());
        }
    }
}
