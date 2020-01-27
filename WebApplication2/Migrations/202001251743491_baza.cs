namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        warehouse_id = c.Int(nullable: false),
                        kolicina = c.Int(nullable: false),
                        poceten_datum = c.DateTime(nullable: false),
                        kraen_datum = c.DateTime(nullable: false),
                        Opis = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
