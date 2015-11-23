using Libreria.DBclass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libreria
{
    public partial class Autor : PantallaInicial
    {
        public Autor()
        {
            InitializeComponent();
        }

        private void Autor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            DBclass.Autor au = new DBclass.Autor();
            au.Nombre = textBox2.Text;
            au.Pais = textBox3.Text;
            au.Telefono = textBox4.Text;
            db.Autor.Add(au);
            db.SaveChanges();

            MessageBox.Show("Registro exito.");
            textBox2.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
