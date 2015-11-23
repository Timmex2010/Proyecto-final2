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
    public partial class ModificarAutor : PantallaInicial
    {
        public ModificarAutor()
        {
            InitializeComponent();
        }

        private void ModificarAutor_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            int idAutor = int.Parse(textBox4.Text);
            var agent = db.Autor
                      .SingleOrDefault(x => x.idAutor == idAutor);
            // where x.id == id
            //select x;

            if (agent != null)
            {
                agent.Nombre = textBox2.Text;
                agent.Pais = textBox3.Text;

                db.SaveChanges();
            }
            MessageBox.Show("Modificar exito.");
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
