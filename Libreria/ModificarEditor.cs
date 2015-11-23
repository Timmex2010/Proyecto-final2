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
    public partial class ModificarEditor : PantallaInicial
    {
        public ModificarEditor()
        {
            InitializeComponent();
        }

        private void ModificarEditor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            int idEditores = int.Parse(textBox1.Text);
            var agent = db.Editores
                      .SingleOrDefault(x => x.idEditores == idEditores);
            // where x.id == id
            //select x;

            if (agent != null)
            {
                agent.Editor = textBox2.Text;
                agent.Direccion = textBox3.Text;
                agent.Telefono = textBox4.Text;
                db.SaveChanges();
            }
            MessageBox.Show("Modificar exito.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
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
