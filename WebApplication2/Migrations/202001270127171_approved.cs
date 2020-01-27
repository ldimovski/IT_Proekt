namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approved : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "approved", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "approved");
        }
    }
}
