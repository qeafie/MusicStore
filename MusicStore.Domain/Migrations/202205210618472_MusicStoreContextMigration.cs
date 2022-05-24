namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MusicStoreContextMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instruments", "ShippingDetails_ShippingDetailsId", c => c.Int());
            CreateIndex("dbo.Instruments", "ShippingDetails_ShippingDetailsId");
            AddForeignKey("dbo.Instruments", "ShippingDetails_ShippingDetailsId", "dbo.ShippingDetails", "ShippingDetailsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instruments", "ShippingDetails_ShippingDetailsId", "dbo.ShippingDetails");
            DropIndex("dbo.Instruments", new[] { "ShippingDetails_ShippingDetailsId" });
            DropColumn("dbo.Instruments", "ShippingDetails_ShippingDetailsId");
        }
    }
}
