namespace _01_DemoMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiaModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Prix = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produits");
        }
    }
}
