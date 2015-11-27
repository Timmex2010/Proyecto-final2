using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Libreria.DBclass
{
    public class PrincipalFP : DbContext
    {
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet <Editores> Editores { get; set; }
       // public DbSet<Registro> SalesPersons { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

    }
}
