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
            // comboBox1.SelectedText= "id";
            comboBox1.ValueMember = "id";
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
            label5.Text = "Current product N/A";
            label6.Text= " ";
            //DataGrid items are set to null
            dataGridView1.DataSource = null;
            //dataGridView1.Items.Refresh();
            //Tmp variable is erased using null
            tmpProduct = null;

        }


        private void button5_Click(object sender, EventArgs e)
        {
            //we make sure there is at least one item in the cart and a sales person has been selected
            if (ShoppingCart.Count > 0 && comboBox1.SelectedIndex > -1)
            {
                //auto dispose after no longer in scope
                using (PrincipalFP db = new PrincipalFP())
                {
                    //All database transactions are considered 1 unit of work
                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //we create the invoice object
                            Invoice inv = new Invoice();
                            inv.SaleDate = DateTime.Now;
                            //assign sales person by querying the database using the Combobox selection

                            comboBox1.SelectedIndex = 0;
                            inv.id =
                               db.Registro.SingleOrDefault(s => s.id == (int)comboBox1.SelectedValue);

                            //for each product in the shopping cart we query the database
                            foreach (var prod in ShoppingCart)
                            {
                                //get product record with id
                                DBclass.Libro p = db.Libro.SingleOrDefault(i => i.idLibro == prod.idLibro);
                                //reduce inventory
                                int RemainingItems = p.Qty - prod.Qty >= 0 ? (p.Qty - prod.Qty) : p.Qty;
                                if (p.Qty == RemainingItems)
                                {
                                    System.Windows.MessageBox.Show(
                                        string.Format(
                                            "Unable to sell Product #{0} not enough inventory, Do want to continue?",
                                            p.idLibro),
                                        "Not Enough Inventory", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                                    //end transaction
                                    dbTransaction.Rollback();
                                    //exit procedure
                                    return;
                                }
                                else
                                {
                                    //If Qty is ok we sell the product
                                    p.Qty = RemainingItems;
                                    inv.SaleList.Add(p);
                                }

                            }

                            //we add the generated invoice to the Invoice Entity (Table)
                            db.Invoice.Add(inv);
                            //Save Changed to the database
                            db.SaveChanges();
                            //Make the changes permanent 
                            dbTransaction.Commit();
                            //We restore the form with defaults
                            CleanUp();
                            //Show confirmation message to the user
                            System.Windows.MessageBox.Show(string.Format("Transaction #{0}  Saved", inv.InvoiceId), "Success", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        }
                        catch
                        {
                            //if an error is produced, we rollback everything
                            dbTransaction.Rollback();
                            //We notify the user of the error
                            System.Windows.MessageBox.Show("Transaction Error, unable to generate invoice", "Fatal Error", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Please select at least one product and a Sales Person", "Data Error",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
