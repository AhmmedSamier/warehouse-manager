namespace warehouse_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnitProducts",
                c => new
                    {
                        Unit_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Unit_Id, t.Product_Id })
                .ForeignKey("dbo.Units", t => t.Unit_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Unit_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnitProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.UnitProducts", "Unit_Id", "dbo.Units");
            DropIndex("dbo.UnitProducts", new[] { "Product_Id" });
            DropIndex("dbo.UnitProducts", new[] { "Unit_Id" });
            DropTable("dbo.UnitProducts");
            DropTable("dbo.Units");
        }
    }
}
