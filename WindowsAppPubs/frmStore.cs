using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppPubs.AdminDatos;
using WindowsAppPubs.Models;

namespace WindowsAppPubs
{
    public partial class frmStore : Form
    {

        public frmStore()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Store agregarStore = new Store()
            {
                stor_id = txtIDStore.Text,
                stor_name = txtNombre.Text,
                stor_address = txtDireccion.Text,
                city = txtCiudad.Text,
                state = txtEstado.Text,
                zip = txtZip.Text,

            };
            int filasAfectadas = DacStore.Nuevo(agregarStore);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Store Agregado!!");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string id = txtIDStore.Text;
            Store store = DacStore.TraerUno(id);

            if (store != null)
            {
                store.stor_name = txtNombre.Text;
                store.stor_address = txtDireccion.Text;
                store.city = txtCiudad.Text;
                store.state = txtEstado.Text;
                store.zip = txtZip.Text;

                int filasAfectadas = DacStore.Modificar(store);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Store Modificado!!");
                }
            }
            
        }

        private void btnTraerUno_Click(object sender, EventArgs e)
        {
            string id = txtIDStore.Text;
            Store traerUno = DacStore.TraerUno(id);
            MessageBox.Show(traerUno.stor_name.ToString());
        }

        private void frmStore_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            List<Store> listaStore = DacStore.Lista();
            gridStores.DataSource = listaStore;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtIDStore.Text;
            Store eliminarId = new Store();
            eliminarId.stor_id = id;
            int filasAfectadas = DacStore.Eliminar(eliminarId);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Store Eliminado!!");
            }
        }
    }
}
