using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.LOGICA;
using Proyecto.DATOS;
using System.Windows.Forms;

namespace Proyecto.PRESENTACION
{
    public partial class Productos : UserControl
    {
        public Productos()
        {
            InitializeComponent();
        }

        int ID;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Today;

            
          
            panelRegistro.Visible = true;
            panelRegistro.Dock = DockStyle.Fill; // espandimos en todo el panel
            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            limpiar();
            lblFecha.Text = fecha.ToShortDateString().ToString();
            mostrarDatos();
           // panelRegistro_Paint();
            panelBtnGuardarPersonal.Visible = true;
            
            
        }



        private void limpiar() {
            
            //  limpiar los textbox de el panel personal
            txtPeso.Clear();
            txtReferencia.Clear();
            txtNombreProducto.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
           // lblHora.Clear();
        }

       
       
      
    
        private void btnVolverPersonal_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
            mostrarDatos();
            txtBuscar.Clear();

        }


        private void mostrarDatos()
        {

            DataTable dt = new DataTable();
            Dproductos funcion = new Dproductos();
            funcion.MostarProductos(ref dt);
            Bases.DiseñoDtv(ref dtvProducto);
            dtvProducto.DataSource = dt;

        }

        private void Productos_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (verificar_Campos() == true)
            {
                insertarProducto();
            }
            else {
                MessageBox.Show("No Puede haber capos vacios","Advertencia");
            }

          
        }

        private void insertarProducto() {

            Lproductos parametros = new Lproductos();
            Dproductos funcion = new Dproductos();

            parametros.NombresProducto = txtNombreProducto.Text;
            parametros.Referencia = txtReferencia.Text;
            parametros.Precio = Convert.ToInt32(txtPrecio.Text);
            parametros.Peso = Convert.ToInt32(txtPeso.Text);
            parametros.Categoria = txtCategoria.Text;
            parametros.Stock = Convert.ToInt32(txtStock.Text);
            parametros.FechaCreacion = lblFecha.Text;
    
       
            if (funcion.InsertarProductos(parametros) == true)
            {
         
                MessageBox.Show("EL PRODUCTO SE HA AGREGADO CORRECTAMENTE", "INFORMACION");
                limpiar();
                panelRegistro.Visible = false;
                mostrarDatos();

            }
            

        }

        private void panelRegistro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dtvProducto.Columns["Editar"].Index) {

                ID = Convert.ToInt32(dtvProducto.SelectedCells[1].Value);
                txtNombreProducto.Text = dtvProducto.SelectedCells[2].Value.ToString();
                txtReferencia.Text = dtvProducto.SelectedCells[3].Value.ToString();
                txtPrecio.Text = dtvProducto.SelectedCells[4].Value.ToString();
                txtPeso.Text = dtvProducto.SelectedCells[5].Value.ToString();
                txtCategoria.Text = dtvProducto.SelectedCells[6].Value.ToString();
                txtStock.Text = dtvProducto.SelectedCells[7].Value.ToString();
                lblFecha.Text =  dtvProducto.SelectedCells[8].Value.ToString();



                panelRegistro.Visible = true;
                panelRegistro.Dock = DockStyle.Fill; // espandimos en todo el panel
                btnGuardar.Visible = false;
                btnEditar.Visible = true;
                panelBtnGuardarPersonal.Visible = true;


            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (verificar_Campos() == true)
            {
                Lproductos parametros = new Lproductos();
                Dproductos funcion = new Dproductos();

                parametros.ID = ID;
                parametros.NombresProducto = txtNombreProducto.Text;
                parametros.Referencia = txtReferencia.Text;
                parametros.Precio = Convert.ToInt32(txtPrecio.Text);
                parametros.Peso = Convert.ToInt32(txtPeso.Text);
                parametros.Categoria = txtCategoria.Text;
                parametros.Stock = Convert.ToInt32(txtStock.Text);



                if (funcion.EditarProductos(parametros) == true)
                {

                    MessageBox.Show("EL PRODUCTO SE HA EDITADO CON EXITO", "INFORMACION");
                    limpiar();
                    panelRegistro.Visible = false;
                    mostrarDatos();

                }

            }

            else {

                MessageBox.Show("No Puede haber capos vacios", "Advertencia");
            }


           

        }

        private void dtvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Lproductos parametros = new Lproductos();
            Dproductos funcion = new Dproductos();
         

            parametros.ID = Convert.ToInt32(dtvProducto.SelectedCells[1].Value);



        DialogResult  resultado =  MessageBox.Show("¿ ESTA SEGURO QUE DESEA ELIMINAR ESTE PRODUCTO ?", "ADVERTENCIA",MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes) {

                if (funcion.EliminarProductos(parametros) == true)
                {

                    MessageBox.Show("EL PRODUCTO SE HA ELIMINADO", "INFORMACION");
                    limpiar();
                    panelRegistro.Visible = false;
                    mostrarDatos();

                }

            }


           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Dproductos funcion = new Dproductos();

            funcion.BuscarProducto(ref dt,txtBuscar.Text);

            dtvProducto.DataSource = dt;

        }


        private bool verificar_Campos() {

            if ((!string.IsNullOrEmpty(txtNombreProducto.Text)) && (!string.IsNullOrEmpty(txtReferencia.Text)) && (!string.IsNullOrEmpty(txtPrecio.Text)) && (!string.IsNullOrEmpty(txtPeso.Text)) && (!string.IsNullOrEmpty(txtCategoria.Text)) && (!string.IsNullOrEmpty(txtStock.Text)))
            {
                return true;
            }

            else {
                return false;
            }

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtPrecio, e);
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtPeso, e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtStock, e);
        }
    } 
}
