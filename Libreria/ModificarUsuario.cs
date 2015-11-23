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
    public partial class ModificarUsuario : PantallaInicial
    {
        public ModificarUsuario()
        {
            InitializeComponent();
        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            int id = int.Parse(textBox12.Text);
            var agent = db.Registro
                      .SingleOrDefault(x => x.id == id);
            // where x.id == id
            //select x;

            if (agent != null)
            {
                agent.Password = int.Parse(textBox11.Text);
                agent.Nombre = textBox10.Text;
                agent.Edad = int.Parse(textBox9.Text);
                agent.Telefono = textBox8.Text;
                agent.Direccion = textBox7.Text;
                db.SaveChanges();
            }
            MessageBox.Show("Modificar exito.");
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
        }
    }
}
