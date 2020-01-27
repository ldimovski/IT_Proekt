namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Od", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Od", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
