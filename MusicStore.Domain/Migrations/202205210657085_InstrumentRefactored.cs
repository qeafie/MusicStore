namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstrumentRefactored : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instruments", "ShippingDetailsId", "dbo.ShippingDetails");
            DropIndex("dbo.Instruments", new[] { "ShippingDetailsId" });
            RenameColumn(table: "dbo.Instruments", name: "ShippingDetailsId", newName: "ShippingDetails_ShippingDetailsId");
            AlterColumn("dbo.Instruments", "ShippingDetails_ShippingDetailsId", c => c.Int());
            CreateIndex("dbo.Instruments", "ShippingDetails_ShippingDetailsId");
            AddForeignKey("dbo.Instruments", "ShippingDetails_ShippingDetailsId", "dbo.ShippingDetails", "ShippingDetailsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instruments", "ShippingDetails_ShippingDetailsId", "dbo.ShippingDetails");
            DropIndex("dbo.Instruments", new[] { "ShippingDetails_ShippingDetailsId" });
            AlterColumn("dbo.Instruments", "ShippingDetails_ShippingDetailsId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Instruments", name: "ShippingDetails_ShippingDetailsId", newName: "ShippingDetailsId");
            CreateIndex("dbo.Instruments", "ShippingDetailsId");
            AddForeignKey("dbo.Instruments", "ShippingDetailsId", "dbo.ShippingDetails", "ShippingDetailsId", cascadeDelete: true);
        }
    }
}
