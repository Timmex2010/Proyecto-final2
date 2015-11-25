namespace Libreria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Libroes", "Precio", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Libroes", "Precio");
        }
    }
}
