using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Libreria.DBclass
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Libro> idLibro { get; set; }

    }
}
