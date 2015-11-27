namespace Libreria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false),
                        id_id = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Registroes", t => t.id_id)
                .Index(t => t.id_id);
            
            AddColumn("dbo.Libroes", "Invoice_InvoiceId", c => c.Int());
            CreateIndex("dbo.Libroes", "Invoice_InvoiceId");
            AddForeignKey("dbo.Libroes", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libroes", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "id_id", "dbo.Registroes");
            DropIndex("dbo.Invoices", new[] { "id_id" });
            DropIndex("dbo.Libroes", new[] { "Invoice_InvoiceId" });
            DropColumn("dbo.Libroes", "Invoice_InvoiceId");
            DropTable("dbo.Invoices");
        }
    }
}
