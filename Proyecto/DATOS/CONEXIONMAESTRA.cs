using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Proyecto.DATOS
{
  public  class CONEXIONMAESTRA
    {


        public static SqlConnection conexion = new SqlConnection(@"Data Source=ING-LLAMAS;Initial Catalog=Cafeteria;Persist Security Info=True;User ID=sa;Password=oscar1012");
        public static void abrir()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
                //  MessageBox.Show("CONEXION ABIERTA");
            }

        }
        public static void cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                //   MessageBox.Show("CONEXION CERRADA");
            }

        }





    }
}
