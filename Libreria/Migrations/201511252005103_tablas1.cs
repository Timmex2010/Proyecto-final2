namespace Libreria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Libroes", "Qty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Libroes", "Qty");
        }
    }
}
