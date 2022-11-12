using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppPubs.Models;

namespace WindowsAppPubs.AdminDatos
{
    public static class DacStore
    {
        static PubsContext context = new PubsContext();
        public static List<Store> Lista()
        {
            List<Store> lista = context.Stores.ToList();
            return lista;
        }

        public static Store TraerUno(string id)
        {
            Store storeId = context.Stores.Find(id);
            return storeId;
        }

        public static int Nuevo(Store st)
        {           
            context.Stores.Add(st);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }

        public static int Modificar(Store st)
        {

            string id = st.stor_id;

            //Modificacion del objeto
            Store storesDB = context.Stores.Find(id);
            if (storesDB != null)
            {
                storesDB.stor_name = st.stor_name;
                storesDB.stor_address = st.stor_name;
                storesDB.city = st.stor_name;
                storesDB.state = st.stor_name;
                storesDB.zip = st.stor_name;
            }

            //Guardar en la DB
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }

        public static int Eliminar(Store st)
        {
            Store findId = context.Stores.Find(st.stor_id);

            if (findId != null)
            {
                context.Stores.Remove(findId);
            }
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }
    }
}
