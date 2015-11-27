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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="Admin"&&textBox2.Text=="123456")
            {
                PantallaInicial vnt = new PantallaInicial();
                vnt.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalidad de Id o Password.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
