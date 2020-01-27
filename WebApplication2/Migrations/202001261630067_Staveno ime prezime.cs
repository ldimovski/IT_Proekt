namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stavenoimeprezime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "embg", c => c.String());
            AddColumn("dbo.AspNetUsers", "telefon", c => c.String());
            AddColumn("dbo.AspNetUsers", "ime", c => c.String());
            AddColumn("dbo.AspNetUsers", "Prezime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Prezime");
            DropColumn("dbo.AspNetUsers", "ime");
            DropColumn("dbo.AspNetUsers", "telefon");
            DropColumn("dbo.AspNetUsers", "embg");
        }
    }
}
