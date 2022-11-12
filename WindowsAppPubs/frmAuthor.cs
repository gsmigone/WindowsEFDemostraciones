using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppPubs.AdminDatos;
using WindowsAppPubs.Models;

namespace WindowsAppPubs
{
    public partial class frmAuthor : Form
    {
        public frmAuthor()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Author author = new Author()
            {
                au_id = txtIDAuthor.Text,
                au_lname = txtLNombre.Text,
                au_fname = txtFNombre.Text,
                phone = txtTelefono.Text,
                address = txtDireccion.Text,
                city = txtCiudad.Text,
                state = txtEstado.Text,
                zip = txtZip.Text,
                contract = true,
            };

            int filasAfectadas = DacAuthor.Nuevo(author);
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Author Agregado!!");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string id = txtIDAuthor.Text;
            Author authorMod = DacAuthor.TraerUno(id);

            if (authorMod.au_id == id)
            {
                authorMod.au_lname = txtLNombre.Text;
                authorMod.au_fname = txtFNombre.Text;
                authorMod.phone = txtTelefono.Text;
                authorMod.address = txtDireccion.Text;
                authorMod.city = txtCiudad.Text;
                authorMod.state = txtEstado.Text;
                authorMod.zip = txtZip.Text;
            }

            int filasAfectadas = DacAuthor.Modificar(authorMod);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Author Modificado!!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtIDAuthor.Text;
            Author author = new Author();
            author.au_id = id;
            int filasAfectadas = DacAuthor.Eliminar(author);
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Author Eliminado!!");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            List<Author> listaAutores = DacAuthor.Lista();
            gridAuthor.DataSource = listaAutores;
        }

        private void btnTraerUno_Click(object sender, EventArgs e)
        {
            Author traeAuthor = DacAuthor.TraerUno("22222");
            MessageBox.Show(traeAuthor.au_lname);
        }
    }
}
