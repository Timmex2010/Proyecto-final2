using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria.DBclass;
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
    public partial class Procesos : Form
    {
        private DBclass.Libro tmpProduct = null;
        private List<DBclass.Libro> ShoppingCart;
        public Procesos()
        {
            InitializeComponent();
        }

        private void Procesos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text.Trim(), @"^\d+$"))
            {
                PrincipalFP db = new PrincipalFP();
                //parse the product code as int from the TextBox
                int idLibro = int.Parse(textBox1.Text);
                //We query the database for the product
                DBclass.Libro p = db.Libro.SingleOrDefault(x => x.idLibro == idLibro);
                if (p != null) //if product was found
                {
                    //store in a temp variable (if user clicks on add we will need this for the Array)
                    tmpProduct = p;
                    //We display the product information on a label 
                    label5.Text = string.Format("ID: {0}, Name: {1}, Price: {2}", p.idLibro, p.Titulo, p.Precio);
                }
                else
                {
                    //if product was not found we display a user notification window
                   // MessageBox.Show("Product not found. (Only numbers allowed)", "Product code error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
