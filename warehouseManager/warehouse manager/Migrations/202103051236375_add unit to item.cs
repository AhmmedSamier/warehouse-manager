namespace warehouse_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addunittoitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Unit_Id", c => c.Int());
            CreateIndex("dbo.Items", "Unit_Id");
            AddForeignKey("dbo.Items", "Unit_Id", "dbo.Units", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Items", new[] { "Unit_Id" });
            DropColumn("dbo.Items", "Unit_Id");
        }
    }
}
