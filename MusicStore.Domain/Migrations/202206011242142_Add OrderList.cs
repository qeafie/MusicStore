namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShippingDetailsInstruments", "ShippingDetails_ShippingDetailsId", "dbo.ShippingDetails");
            DropForeignKey("dbo.ShippingDetailsInstruments", "Instrument_InstrumentId", "dbo.Instruments");
            DropIndex("dbo.ShippingDetailsInstruments", new[] { "ShippingDetails_ShippingDetailsId" });
            DropIndex("dbo.ShippingDetailsInstruments", new[] { "Instrument_InstrumentId" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ShippingDetailsId = c.Int(nullable: false),
                        InstrumentId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Instruments", t => t.InstrumentId, cascadeDelete: false)
                .ForeignKey("dbo.ShippingDetails", t => t.ShippingDetailsId, cascadeDelete:false)
                .Index(t => t.ShippingDetailsId)
                .Index(t => t.InstrumentId);
            
            AddColumn("dbo.ShippingDetails", "Instrument_InstrumentId", c => c.Int());
            CreateIndex("dbo.ShippingDetails", "Instrument_InstrumentId");
            AddForeignKey("dbo.ShippingDetails", "Instrument_InstrumentId", "dbo.Instruments", "InstrumentId");
            DropTable("dbo.ShippingDetailsInstruments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShippingDetailsInstruments",
                c => new
                    {
                        ShippingDetails_ShippingDetailsId = c.Int(nullable: false),
                        Instrument_InstrumentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShippingDetails_ShippingDetailsId, t.Instrument_InstrumentId });
            
            DropForeignKey("dbo.ShippingDetails", "Instrument_InstrumentId", "dbo.Instruments");
            DropForeignKey("dbo.Orders", "ShippingDetailsId", "dbo.ShippingDetails");
            DropForeignKey("dbo.Orders", "InstrumentId", "dbo.Instruments");
            DropIndex("dbo.Orders", new[] { "InstrumentId" });
            DropIndex("dbo.Orders", new[] { "ShippingDetailsId" });
            DropIndex("dbo.ShippingDetails", new[] { "Instrument_InstrumentId" });
            DropColumn("dbo.ShippingDetails", "Instrument_InstrumentId");
            DropTable("dbo.Orders");
            CreateIndex("dbo.ShippingDetailsInstruments", "Instrument_InstrumentId");
            CreateIndex("dbo.ShippingDetailsInstruments", "ShippingDetails_ShippingDetailsId");
            AddForeignKey("dbo.ShippingDetailsInstruments", "Instrument_InstrumentId", "dbo.Instruments", "InstrumentId", cascadeDelete: true);
            AddForeignKey("dbo.ShippingDetailsInstruments", "ShippingDetails_ShippingDetailsId", "dbo.ShippingDetails", "ShippingDetailsId", cascadeDelete: true);
        }
    }
}
