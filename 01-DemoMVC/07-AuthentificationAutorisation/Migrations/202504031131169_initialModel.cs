namespace _07_AuthentificationAutorisation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            //Insérer des données de test
            Sql("Insert into Roles(Name) values ('Admin')");
            Sql("Insert into Roles(Name) values ('Manager')");
            Sql("Insert into Roles(Name) values ('Normal')");

            Sql("Insert into Users(Username,Password,RoleId) values ('admin', 'admin', 1)");
            Sql("Insert into Users(Username,Password,RoleId) values ('manager', 'manager', 2)");
            Sql("Insert into Users(Username,Password,RoleId) values ('normal', 'normal', 3)");

        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
