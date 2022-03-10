using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;
using Proyecto.LOGICA;
using Proyecto.DATOS;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.PRESENTACION
{
    public partial class Ventas : UserControl
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {


            DataTable dt = new DataTable();
            Dproductos funcion = new Dproductos();
            funcion.MostarProductos(ref dt);

            comboBox1.DisplayMember = "Nombre de Producto";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = dt;

            Bases.DiseñoDtv(ref dtvVentas);
            mostrarVentas();


        }


        private void mostrarVentas() {


            try
            {
                CONEXIONMAESTRA.abrir();

                DataTable dt = new DataTable();
               
       
                SqlDataAdapter da = new SqlDataAdapter("mostrarVenta", CONEXIONMAESTRA.conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                dtvVentas.DataSource = dt;
                label4.Text = "VENTAS";
                label4.Visible = true;
                label8.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        private void bntComprar_Click(object sender, EventArgs e)
        {


            if (numericUpDown1.Value > 0)
            {

                int id = Convert.ToInt32(comboBox1.SelectedValue);
                int cant = Convert.ToInt32(numericUpDown1.Value);

                try
                {
                    CONEXIONMAESTRA.abrir();

                    SqlCommand cmd = new SqlCommand("ventas", CONEXIONMAESTRA.conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Cant", cant);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Su Compra a hecho exitosa", "Informacion");
                    insertarventa();
                    mostrarVentas();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Informacion");

                }

                finally
                {
                    CONEXIONMAESTRA.cerrar();
                }

            }


            else {

                MessageBox.Show("La cantidad de Productos debe ser mayor o igual a uno", "Informacion");
            }





        }


        private void insertarventa() {

            int id = Convert.ToInt32(comboBox1.SelectedValue);
            int cant = Convert.ToInt32(numericUpDown1.Value);

            try
            {
                CONEXIONMAESTRA.abrir();

                SqlCommand cmd = new SqlCommand("insertarventa", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Producto", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Cant", cant);
                cmd.ExecuteNonQuery();
          

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informacion");

            }

            finally
            {
                CONEXIONMAESTRA.cerrar();
            }


        }


        private void btnConsultarVentas_Click(object sender, EventArgs e)
        {

            try
            {
                CONEXIONMAESTRA.abrir();

                DataTable dt = new DataTable();


                SqlDataAdapter da = new SqlDataAdapter("ProductoMayorVenta", CONEXIONMAESTRA.conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                dtvVentas.DataSource = dt;
                label8.Text = "Producto con mayor Venta";
                label8.Visible = true;
                label4.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally
            {
                CONEXIONMAESTRA.cerrar();
            }


        }

        private void btnConsultarStock_Click(object sender, EventArgs e)
        {
            try
            {
                CONEXIONMAESTRA.abrir();

                DataTable dt = new DataTable();


                SqlDataAdapter da = new SqlDataAdapter("ProductoMayorStock", CONEXIONMAESTRA.conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                dtvVentas.DataSource = dt;
                label8.Text = "Producto con Mayor Stock";
                label8.Visible = true;
                label4.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarVentas();
        }
    }
}
