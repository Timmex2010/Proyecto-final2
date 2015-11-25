using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Libreria.DBclass
{
    public class Libro
    {
        [Key]
        public int idLibro { get; set; }
        public string Titulo { get; set; }
        public string Fecha { get; set; }
        public string Editores { get; set; }
        public int Precio { get; set; }
        public int Qty { get; set; }
        public virtual ICollection<Registro> id { get; set; }
        public virtual ICollection<Autor> idAutor { get; set; }
        public virtual ICollection<Editores> idEditores { get; set; }
        public virtual ICollection<Categoria> idCategoria { get; set; }

    }
}
