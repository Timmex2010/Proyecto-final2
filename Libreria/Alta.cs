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
using System.Text.RegularExpressions;

namespace Libreria
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            PrincipalFP db = new PrincipalFP();
            Registro log1 = new Registro();

            log1.Password = int.Parse(textBox11.Text);
            log1.Nombre = textBox10.Text;
            log1.Edad = int.Parse(textBox9.Text);
            log1.Telefono = textBox8.Text;
            log1.Direccion = textBox7.Text;

            db.Registro.Add(log1);
            db.SaveChanges();



            MessageBox.Show("Registro exito.");
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
