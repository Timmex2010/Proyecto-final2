using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Libreria.DBclass
{
    public class Autor
    {
        [Key]
        public int idAutor { get; set; }

        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
    }
}
