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
    public partial class Medio : Form
    {
        public Medio()
        {
            InitializeComponent();
        }

        private void Medio_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Procesos vnt = new Procesos();
            vnt.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login vnt = new Login();
            vnt.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow vnt = new MainWindow();
            vnt.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Procesos vnt = new Procesos();
            vnt.Show();
        }
    }
}
