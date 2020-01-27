namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stavenoopisvoorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Od", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Od");
        }
    }
}
