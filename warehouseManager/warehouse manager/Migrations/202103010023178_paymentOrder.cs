namespace warehouse_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentOrders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.PaymentOrders", new[] { "Customer_Id" });
            DropTable("dbo.PaymentOrders");
        }
    }
}
