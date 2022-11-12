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
using WindowsAppPubs.Models;

namespace WindowsAppPubs
{
    public partial class Form1 : Form
    {
        private PubsContext context = new PubsContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //creamos la instancia
            Publisher publisher = new Publisher() { pub_id = "0000" ,pub_name = "Tongas", city = "Mar del plata", state= "BS",country="ARGENTINA" };

            //DBset
            context.Publishers.Add(publisher);

            //guardar en la tabla
            int filasAfectadas = context.SaveChanges();
            if (filasAfectadas > 0)
            {
                MessageBox.Show("OK");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //buscar 
            string id = "0877";

            //Modificacion del objeto
            Publisher publisherDB = context.Publishers.Find(id);
            if (publisherDB != null)
            {
                publisherDB.pub_name = "Express Gaston";
                publisherDB.city = "MDQ";
            }

            //Guardar en la DB
            int filasAfectadas = context.SaveChanges();
            if (filasAfectadas > 0)
            {
                MessageBox.Show("OK");
            }
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            string id = "0000";

            //Buscar el objeto en la DB

            var publisherDB = context.Publishers.Find(id);

            if (publisherDB != null)
            {
                //remover
                context.Publishers.Remove(publisherDB);
                int filasAfectadas = context.SaveChanges();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("OK Eliminar");
                }
            }
        }

        private void btnListarTodo_Click(object sender, EventArgs e)
        {
            List<Publisher> lista = context.Publishers.ToList();//conectar db, select..., cierra conexion

            gridPublishers.DataSource = lista;
        }
    }
}
