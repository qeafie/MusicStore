namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instruments", "ShippingDetails_ShippingDetailsId", "dbo.ShippingDetails");
            DropIndex("dbo.Instruments", new[] { "ShippingDetails_ShippingDetailsId" });
            RenameColumn(table: "dbo.Instruments", name: "ShippingDetails_ShippingDetailsId", newName: "ShippingDetailsId");
            AlterColumn("dbo.Instruments", "ShippingDetailsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Instruments", "ShippingDetailsId");
            AddForeignKey("dbo.Instruments", "ShippingDetailsId", "dbo.ShippingDetails", "ShippingDetailsId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instruments", "ShippingDetailsId", "dbo.ShippingDetails");
            DropIndex("dbo.Instruments", new[] { "ShippingDetailsId" });
            AlterColumn("dbo.Instruments", "ShippingDetailsId", c => c.Int());
            RenameColumn(table: "dbo.Instruments", name: "ShippingDetailsId", newName: "ShippingDetails_ShippingDetailsId");
            CreateIndex("dbo.Instruments", "ShippingDetails_ShippingDetailsId");
            AddForeignKey("dbo.Instruments", "ShippingDetails_ShippingDetailsId", "dbo.ShippingDetails", "ShippingDetailsId");
        }
    }
}
