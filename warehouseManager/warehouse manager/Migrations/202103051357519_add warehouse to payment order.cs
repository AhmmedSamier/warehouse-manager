namespace warehouse_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwarehousetopaymentorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentOrders", "Warehouse_Id", c => c.Int());
            CreateIndex("dbo.PaymentOrders", "Warehouse_Id");
            AddForeignKey("dbo.PaymentOrders", "Warehouse_Id", "dbo.Warehouses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentOrders", "Warehouse_Id", "dbo.Warehouses");
            DropIndex("dbo.PaymentOrders", new[] { "Warehouse_Id" });
            DropColumn("dbo.PaymentOrders", "Warehouse_Id");
        }
    }
}
