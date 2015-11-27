namespace Libreria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Libroes", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Libroes", new[] { "Invoice_InvoiceId" });
            CreateTable(
                "dbo.InvoiceLibroes",
                c => new
                    {
                        Invoice_InvoiceId = c.Int(nullable: false),
                        Libro_idLibro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Invoice_InvoiceId, t.Libro_idLibro })
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Libroes", t => t.Libro_idLibro, cascadeDelete: true)
                .Index(t => t.Invoice_InvoiceId)
                .Index(t => t.Libro_idLibro);
            
            DropColumn("dbo.Libroes", "Invoice_InvoiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Libroes", "Invoice_InvoiceId", c => c.Int());
            DropForeignKey("dbo.InvoiceLibroes", "Libro_idLibro", "dbo.Libroes");
            DropForeignKey("dbo.InvoiceLibroes", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceLibroes", new[] { "Libro_idLibro" });
            DropIndex("dbo.InvoiceLibroes", new[] { "Invoice_InvoiceId" });
            DropTable("dbo.InvoiceLibroes");
            CreateIndex("dbo.Libroes", "Invoice_InvoiceId");
            AddForeignKey("dbo.Libroes", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
        }
    }
}
