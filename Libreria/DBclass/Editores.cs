using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Libreria.DBclass
{
    public class Editores
    {
        [Key]
        public int idEditores{ get; set; }
        public string Editor { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
