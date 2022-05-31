namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefacroredInstrument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShippingDetails", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.ShippingDetails", "Email", c => c.String(nullable: false));
            DropColumn("dbo.ShippingDetails", "GiftWrap");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShippingDetails", "GiftWrap", c => c.Boolean(nullable: false));
            DropColumn("dbo.ShippingDetails", "Email");
            DropColumn("dbo.ShippingDetails", "PhoneNumber");
        }
    }
}
