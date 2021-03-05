namespace warehouse_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexchangeorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExchangeOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        DestinationWarehouse_Id = c.Int(),
                        SourceWarehouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Warehouses", t => t.DestinationWarehouse_Id)
                .ForeignKey("dbo.Warehouses", t => t.SourceWarehouse_Id)
                .Index(t => t.DestinationWarehouse_Id)
                .Index(t => t.SourceWarehouse_Id);
            
            AddColumn("dbo.Items", "ExchangeOrder_Id", c => c.Int());
            CreateIndex("dbo.Items", "ExchangeOrder_Id");
            AddForeignKey("dbo.Items", "ExchangeOrder_Id", "dbo.ExchangeOrders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ExchangeOrder_Id", "dbo.ExchangeOrders");
            DropForeignKey("dbo.ExchangeOrders", "SourceWarehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.ExchangeOrders", "DestinationWarehouse_Id", "dbo.Warehouses");
            DropIndex("dbo.ExchangeOrders", new[] { "SourceWarehouse_Id" });
            DropIndex("dbo.ExchangeOrders", new[] { "DestinationWarehouse_Id" });
            DropIndex("dbo.Items", new[] { "ExchangeOrder_Id" });
            DropColumn("dbo.Items", "ExchangeOrder_Id");
            DropTable("dbo.ExchangeOrders");
        }
    }
}
