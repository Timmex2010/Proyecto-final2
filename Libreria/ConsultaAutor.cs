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
    public partial class ConsultaAutor : PantallaInicial
    {
        public ConsultaAutor()
        {
            InitializeComponent();
        }

        private void ConsultaAutor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            int idAutor = int.Parse(textBox1.Text);
            var registros = from s in db.Autor
                            where s.idAutor == idAutor
                            select new
                            {
                                s.idAutor,
                                s.Nombre,
                                s.Pais
                            };
            dataGridView1.DataSource = registros.ToList();
        }
    }
}
