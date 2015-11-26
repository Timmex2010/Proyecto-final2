using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DBclass
{
    public class Invoice
    {
        public Invoice()
        {
            this.id = new Registro ();
            this.SaleList = new List<Libro>();
        }

        public int InvoiceId { get; set; }

        public virtual Registro id { get; set; }

        public DateTime SaleDate { get; set; }

        public virtual List<Libro> SaleList { get; set; }
    }
}
