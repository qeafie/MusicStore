namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstrumentMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instruments", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instruments", "Quantity");
        }
    }
}
