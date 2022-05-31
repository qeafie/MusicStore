namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationBetweenShipDetAndInst : DbMigration
    {
        public override void Up()
        {
            Sql("alter table dbo.Instruments drop constraint [FK_dbo.Instruments_dbo.ShippingDetails_ShippingDetails_ShippingDetailsId];");
            DropForeignKey("dbo.Instruments", "ShippingDetailsId", "dbo.ShippingDetails");
            DropIndex("dbo.Instruments", new[] { "ShippingDetailsId" });
            CreateTable(
                "dbo.ShippingDetailsInstruments",
                c => new
                    {
                        ShippingDetails_ShippingDetailsId = c.Int(nullable: false),
                        Instrument_InstrumentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShippingDetails_ShippingDetailsId, t.Instrument_InstrumentId })
                .ForeignKey("dbo.ShippingDetails", t => t.ShippingDetails_ShippingDetailsId, cascadeDelete: true)
                .ForeignKey("dbo.Instruments", t => t.Instrument_InstrumentId, cascadeDelete: true)
                .Index(t => t.ShippingDetails_ShippingDetailsId)
                .Index(t => t.Instrument_InstrumentId);
            
            DropColumn("dbo.Instruments", "ShippingDetailsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instruments", "ShippingDetailsId", c => c.Int());
            DropForeignKey("dbo.ShippingDetailsInstruments", "Instrument_InstrumentId", "dbo.Instruments");
            DropForeignKey("dbo.ShippingDetailsInstruments", "ShippingDetails_ShippingDetailsId", "dbo.ShippingDetails");
            DropIndex("dbo.ShippingDetailsInstruments", new[] { "Instrument_InstrumentId" });
            DropIndex("dbo.ShippingDetailsInstruments", new[] { "ShippingDetails_ShippingDetailsId" });
            DropTable("dbo.ShippingDetailsInstruments");
            CreateIndex("dbo.Instruments", "ShippingDetailsId");
            AddForeignKey("dbo.Instruments", "ShippingDetailsId", "dbo.ShippingDetails", "ShippingDetailsId");
        }
    }
}
