namespace Libreria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registroes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Password = c.Int(nullable: false),
                        Nombre = c.String(),
                        Edad = c.Int(nullable: false),
                        Telefono = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registroes");
        }
    }
}
