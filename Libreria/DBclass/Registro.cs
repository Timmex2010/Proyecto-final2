using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Libreria.DBclass
{
    public class Registro
    {
        public int id { get; set; }
        public int Password { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Libro> idLibro { get; set; }

    }
}
