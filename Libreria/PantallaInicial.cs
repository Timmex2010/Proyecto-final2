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
    public partial class PantallaInicial : Form
    {
        public PantallaInicial()
        {
            InitializeComponent();
        }

        private void libroToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Autor vnt = new Autor();
            vnt.Show();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Alta vnt = new Alta();
            vnt.Show();
        }

        private void autorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Libro vnt = new Libro();
            vnt.Show();
        }

        private void comentarioToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Editor vnt = new Editor();
            vnt.Show();
        }

        private void categoriaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Categoria vnt = new Categoria();
            vnt.Show();
        }

        private void porClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarUsuario vnt = new ModificarUsuario();
            vnt.Show();
        }

        private void libroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarLibro vnt = new ModificarLibro();
            vnt.Show();
        }

        private void comentarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModificarEditor vnt = new ModificarEditor();
            vnt.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarCatalogo vnt = new ModificarCatalogo();
            vnt.Show();
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarAutor vnt = new ModificarAutor();
            vnt.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarUsuario vnt = new EliminarUsuario();
            vnt.Show();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarAutor vnt = new EliminarAutor();
            vnt.Show();
        }

        private void libroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EliminarLibro vnt = new EliminarLibro();
            vnt.Show();
        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EliminarCategoria vnt = new EliminarCategoria();
            vnt.Show();
        }

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarEditor vnt = new EliminarEditor();
            vnt.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void porClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaUsuario vnt = new ConsultaUsuario();
            vnt.Show();
        }

        private void porFotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaAutor vnt = new ConsultaAutor();
            vnt.Show();
        }

        private void porOcupacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaLibro vnt = new ConsultaLibro();
            vnt.Show();
        }

        private void categoriaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ConsultaCategoria vnt = new ConsultaCategoria();
            vnt.Show();
        }

        private void editorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaEditor vnt = new ConsultaEditor();
            vnt.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formulario1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca vnt = new Acerca();
            vnt.Show();
        }

        private void ordenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos vnt = new Procesos();
            vnt.Show();
        }
    }
}
