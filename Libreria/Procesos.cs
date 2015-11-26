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
            ShoppingCart = new List<DBclass.Libro>();
        }

        private void Procesos_Load(object sender, EventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            comboBox1.DataSource = db.Registro.ToList();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.SelectedText= "id";
            comboBox1.SelectedIndex = 0;
        }

        private void BindDataGrid()
        {
            //we query the array cart and add a new calculated field Subtotal
            var cartItems = from s in ShoppingCart
                            select new
                            {
                                s.idLibro,
                                s.Titulo,
                                s.Qty,
                                s.Precio,
                                SubTotal = s.Qty * s.Precio
                            };

            //refresh dataGridview-----------
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cartItems.ToList();
                            //dataGridView1.DataSource = registros.ToList();


            //we add the total with sum(price) and apply a currency formating.
            label6.Text = string.Format("Total: {0}", ShoppingCart.Sum(x => x.Precio * x.Qty).ToString("C"));
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

            //we first check if a product has been selected
            if (tmpProduct == null)
            {
                //if not we call the search button method
                button2_Click(null, null);
                //we check again if the product was found
                if (tmpProduct == null)
                {
                    //if tmpProduct is empty (Product not found) we exit the procedure

                    System.Windows.MessageBox.Show("No product was selected", "No product", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                    //exit procedure
                    return;
                }
            }



            //product quantity
            int qty;

            // we try to parse the number of the textbox if the number is invalid 
            int.TryParse(textBox3.Text, out qty);
            //if qty is 0 we assign 0 otherwise we assign the actual parsed value
            qty = qty == 0 ? 1 : qty;
            //really basic validation that checks inventory
            if (qty <= tmpProduct.Qty)
            {
                //we check if product is not already in the cart if it is we remove the old one
                ShoppingCart.RemoveAll(s => s.idLibro == tmpProduct.idLibro);
                //we add the product to the Cart
                ShoppingCart.Add(new DBclass.Libro()
                {
                     idLibro = tmpProduct.idLibro,
                     Titulo = tmpProduct.Titulo,
                     Precio = tmpProduct.Precio,
                     Qty = qty
                });

                //perform  query on Shopping Cart to select certain fields and perform subtotal operation 
                BindDataGrid();
                //<----------------------
                //cleanup variables
                tmpProduct = null;
                //once the products had been added we clear the textbox of code and quantity.
                textBox1.Text = string.Empty;
                textBox3.Text = string.Empty;
                //clean up current product label
                label5.Text = "Current product N/A";
            }
            else
            {
                System.Windows.MessageBox.Show("Not enough Inventory", "Inventory Error", MessageBoxButton.OK,
                  MessageBoxImage.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CleanUp();
        }

        private void CleanUp()
        {
            //shopping cart = a new empty list
            ShoppingCart = new List<DBclass.Libro>();
            //Textboxes and labels are set to defaults
            textBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            label6.Text= " ";
            //DataGrid items are set to null
            dataGridView1.DataSource = null;
            //dataGridView1.Items.Refresh();
            //Tmp variable is erased using null
            tmpProduct = null;

        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
