namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModelnapraven : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "magacini_Id", c => c.Int());
            CreateIndex("dbo.Orders", "magacini_Id");
            AddForeignKey("dbo.Orders", "magacini_Id", "dbo.Warehouses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "magacini_Id", "dbo.Warehouses");
            DropIndex("dbo.Orders", new[] { "magacini_Id" });
            DropColumn("dbo.Orders", "magacini_Id");
        }
    }
}
