namespace warehouse_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoiceItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        PaymentOrder_Id = c.Int(),
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.PaymentOrders", t => t.PaymentOrder_Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.PaymentOrder_Id)
                .Index(t => t.Unit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItems", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.InvoiceItems", "PaymentOrder_Id", "dbo.PaymentOrders");
            DropForeignKey("dbo.InvoiceItems", "Item_Id", "dbo.Items");
            DropIndex("dbo.InvoiceItems", new[] { "Unit_Id" });
            DropIndex("dbo.InvoiceItems", new[] { "PaymentOrder_Id" });
            DropIndex("dbo.InvoiceItems", new[] { "Item_Id" });
            DropTable("dbo.InvoiceItems");
        }
    }
}
