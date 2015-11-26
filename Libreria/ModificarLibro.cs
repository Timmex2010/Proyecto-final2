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
    public partial class ModificarLibro : PantallaInicial
    {
        public ModificarLibro()
        {
            InitializeComponent();
        }

        private void ModificarLibro_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            int idLibro = int.Parse(textBox2.Text);
            var agent = db.Libro
                      .SingleOrDefault(x => x.idLibro == idLibro);
            // where x.id == id
            //select x;

            if (agent != null)
            {
                agent.Fecha = textBox3.Text;
                agent.Titulo = textBox4.Text;
                agent.Editores = textBox1.Text;
                agent.Precio = int.Parse(textBox5.Text);
                agent.Qty = int.Parse(textBox6.Text);


                db.SaveChanges();
            }
            MessageBox.Show("Modificar exito.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
