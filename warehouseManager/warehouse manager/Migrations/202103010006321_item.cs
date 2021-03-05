namespace warehouse_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class item : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailableQuantity = c.Int(nullable: false),
                        SuppliedQuantity = c.Int(nullable: false),
                        ProductionDate = c.DateTime(nullable: false, storeType: "date"),
                        Expiry = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        SupplyingOrder_Id = c.Int(),
                        Warehouse_Id = c.Int(),
                        Provider_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.SupplyingOrders", t => t.SupplyingOrder_Id)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id)
                .ForeignKey("dbo.Providers", t => t.Provider_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.SupplyingOrder_Id)
                .Index(t => t.Warehouse_Id)
                .Index(t => t.Provider_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.Items", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.Items", "SupplyingOrder_Id", "dbo.SupplyingOrders");
            DropForeignKey("dbo.Items", "Product_Id", "dbo.Products");
            DropIndex("dbo.Items", new[] { "Provider_Id" });
            DropIndex("dbo.Items", new[] { "Warehouse_Id" });
            DropIndex("dbo.Items", new[] { "SupplyingOrder_Id" });
            DropIndex("dbo.Items", new[] { "Product_Id" });
            DropTable("dbo.Items");
        }
    }
}
