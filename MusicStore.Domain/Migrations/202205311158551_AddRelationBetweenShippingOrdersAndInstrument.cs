namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenShippingOrdersAndInstrument : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Instruments", name: "ShippingDetails_ShippingDetailsId", newName: "ShippingDetailsId");
            RenameIndex(table: "dbo.Instruments", name: "IX_ShippingDetails_ShippingDetailsId", newName: "IX_ShippingDetailsId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Instruments", name: "IX_ShippingDetailsId", newName: "IX_ShippingDetails_ShippingDetailsId");
            RenameColumn(table: "dbo.Instruments", name: "ShippingDetailsId", newName: "ShippingDetails_ShippingDetailsId");
        }
    }
}
