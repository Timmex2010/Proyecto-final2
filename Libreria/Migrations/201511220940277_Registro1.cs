namespace Libreria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registro1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libroes",
                c => new
                    {
                        idLibro = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Fecha = c.String(),
                        Editores = c.String(),
                    })
                .PrimaryKey(t => t.idLibro);
            
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        idAutor = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Pais = c.String(),
                        Telefono = c.String(),
                        Libro_idLibro = c.Int(),
                    })
                .PrimaryKey(t => t.idAutor)
                .ForeignKey("dbo.Libroes", t => t.Libro_idLibro)
                .Index(t => t.Libro_idLibro);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            CreateTable(
                "dbo.Editores",
                c => new
                    {
                        idEditores = c.Int(nullable: false, identity: true),
                        Editor = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                        Libro_idLibro = c.Int(),
                    })
                .PrimaryKey(t => t.idEditores)
                .ForeignKey("dbo.Libroes", t => t.Libro_idLibro)
                .Index(t => t.Libro_idLibro);
            
            CreateTable(
                "dbo.LibroRegistroes",
                c => new
                    {
                        Libro_idLibro = c.Int(nullable: false),
                        Registro_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Libro_idLibro, t.Registro_id })
                .ForeignKey("dbo.Libroes", t => t.Libro_idLibro, cascadeDelete: true)
                .ForeignKey("dbo.Registroes", t => t.Registro_id, cascadeDelete: true)
                .Index(t => t.Libro_idLibro)
                .Index(t => t.Registro_id);
            
            CreateTable(
                "dbo.CategoriaLibroes",
                c => new
                    {
                        Categoria_idCategoria = c.Int(nullable: false),
                        Libro_idLibro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Categoria_idCategoria, t.Libro_idLibro })
                .ForeignKey("dbo.Categorias", t => t.Categoria_idCategoria, cascadeDelete: true)
                .ForeignKey("dbo.Libroes", t => t.Libro_idLibro, cascadeDelete: true)
                .Index(t => t.Categoria_idCategoria)
                .Index(t => t.Libro_idLibro);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Editores", "Libro_idLibro", "dbo.Libroes");
            DropForeignKey("dbo.CategoriaLibroes", "Libro_idLibro", "dbo.Libroes");
            DropForeignKey("dbo.CategoriaLibroes", "Categoria_idCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Autors", "Libro_idLibro", "dbo.Libroes");
            DropForeignKey("dbo.LibroRegistroes", "Registro_id", "dbo.Registroes");
            DropForeignKey("dbo.LibroRegistroes", "Libro_idLibro", "dbo.Libroes");
            DropIndex("dbo.CategoriaLibroes", new[] { "Libro_idLibro" });
            DropIndex("dbo.CategoriaLibroes", new[] { "Categoria_idCategoria" });
            DropIndex("dbo.LibroRegistroes", new[] { "Registro_id" });
            DropIndex("dbo.LibroRegistroes", new[] { "Libro_idLibro" });
            DropIndex("dbo.Editores", new[] { "Libro_idLibro" });
            DropIndex("dbo.Autors", new[] { "Libro_idLibro" });
            DropTable("dbo.CategoriaLibroes");
            DropTable("dbo.LibroRegistroes");
            DropTable("dbo.Editores");
            DropTable("dbo.Categorias");
            DropTable("dbo.Autors");
            DropTable("dbo.Libroes");
        }
    }
}
