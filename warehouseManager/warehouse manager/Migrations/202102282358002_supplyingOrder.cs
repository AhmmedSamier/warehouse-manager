namespace warehouse_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplyingOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplyingOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Provider_Id = c.Int(),
                        Warehouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.Provider_Id)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id)
                .Index(t => t.Provider_Id)
                .Index(t => t.Warehouse_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplyingOrders", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.SupplyingOrders", "Provider_Id", "dbo.Providers");
            DropIndex("dbo.SupplyingOrders", new[] { "Warehouse_Id" });
            DropIndex("dbo.SupplyingOrders", new[] { "Provider_Id" });
            DropTable("dbo.SupplyingOrders");
        }
    }
}
