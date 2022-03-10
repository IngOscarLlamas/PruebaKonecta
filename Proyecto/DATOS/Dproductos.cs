using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Proyecto.LOGICA;
using System.Windows.Forms;

using System.Threading.Tasks;

namespace Proyecto.DATOS
{
    public class Dproductos
    {
        public bool InsertarProductos(Lproductos parametro) {
            try
            {
                CONEXIONMAESTRA.abrir();
                // para insertar editar o eliminar de trabaja sqlCommand
                SqlCommand cmd = new SqlCommand("insertarProducto", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProducto", parametro.NombresProducto);
                cmd.Parameters.AddWithValue("@Referencia", parametro.Referencia);
                cmd.Parameters.AddWithValue("@Precio", parametro.Precio);
                cmd.Parameters.AddWithValue("@Peso", parametro.Peso);
                cmd.Parameters.AddWithValue("@Categoria", parametro.Categoria);
                cmd.Parameters.AddWithValue("@Stock", parametro.Stock);
                cmd.Parameters.AddWithValue("@FechaCreacion", parametro.FechaCreacion);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }

            finally {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public bool EditarProductos(Lproductos parametro)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                // para insertar editar o eliminar de trabaja sqlCommand
                SqlCommand cmd = new SqlCommand("editarProductos", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", parametro.ID);
                cmd.Parameters.AddWithValue("@NombreProducto", parametro.NombresProducto);
                cmd.Parameters.AddWithValue("@Referencia", parametro.Referencia);
                cmd.Parameters.AddWithValue("@Precio", parametro.Precio);
                cmd.Parameters.AddWithValue("@Peso", parametro.Peso);
                cmd.Parameters.AddWithValue("@Categoria", parametro.Categoria);
                cmd.Parameters.AddWithValue("@Stock", parametro.Stock);
          
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }

            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public bool EliminarProductos(Lproductos parametro)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                // para insertar editar o eliminar de trabaja sqlCommand
                SqlCommand cmd = new SqlCommand("eliminarProductos", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", parametro.ID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }

            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }


        public void MostarProductos(ref DataTable dt) { 
     

            
            try
            {
                CONEXIONMAESTRA.abrir();

         
                SqlDataAdapter da = new SqlDataAdapter("mostrarProducto", CONEXIONMAESTRA.conexion);
                // SqlDataAdapter da = new SqlDataAdapter("select * from Productos", CONEXIONMAESTRA.conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public void BuscarProducto(ref DataTable dt, string buscador)
        {


            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarProducto", CONEXIONMAESTRA.conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                da.Fill(dt);




            }
            catch (Exception)
            {

                throw;
            }

            finally
            {

            }

        }

    }
}
