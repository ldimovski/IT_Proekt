namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodadenuser_mail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "user_mail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "user_mail");
        }
    }
}
