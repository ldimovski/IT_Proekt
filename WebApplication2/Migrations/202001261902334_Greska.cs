namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Greska : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "user_mail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "user_mail", c => c.String());
        }
    }
}
