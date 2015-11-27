using Libreria.DBclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Libreria
{
    public partial class ConsultaComprar : PantallaInicial
    {
        public ConsultaComprar()
        {
            InitializeComponent();
        }

        private void ConsultaComprar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            int id = int.Parse(textBox1.Text);
            var registros = from s in db.Invoice
                            where s.InvoiceId == id
                            select new
                            {
                                s.InvoiceId,
                                s.SaleDate,
                                s.id
                            };
            dataGridView1.DataSource = registros.ToList();
        }
    }
}
