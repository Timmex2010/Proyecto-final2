namespace Libreria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registro2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LibroRegistroes", newName: "RegistroLibroes");
            RenameTable(name: "dbo.CategoriaLibroes", newName: "LibroCategorias");
            DropPrimaryKey("dbo.RegistroLibroes");
            DropPrimaryKey("dbo.LibroCategorias");
            AddPrimaryKey("dbo.RegistroLibroes", new[] { "Registro_id", "Libro_idLibro" });
            AddPrimaryKey("dbo.LibroCategorias", new[] { "Libro_idLibro", "Categoria_idCategoria" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LibroCategorias");
            DropPrimaryKey("dbo.RegistroLibroes");
            AddPrimaryKey("dbo.LibroCategorias", new[] { "Categoria_idCategoria", "Libro_idLibro" });
            AddPrimaryKey("dbo.RegistroLibroes", new[] { "Libro_idLibro", "Registro_id" });
            RenameTable(name: "dbo.LibroCategorias", newName: "CategoriaLibroes");
            RenameTable(name: "dbo.RegistroLibroes", newName: "LibroRegistroes");
        }
    }
}
