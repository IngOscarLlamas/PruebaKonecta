using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Proyecto.LOGICA
{
  public class Bases
    {
        public static void DiseñoDtv(ref DataGridView Listado) {
            Listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // Listado.BackgroundColor = Color.Red;   
            Listado.BackgroundColor = Color.FromArgb(29, 29 ,29);
            Listado.EnableHeadersVisualStyles = false; //Desabilitar el estilo a la cabecera
            Listado.BorderStyle = BorderStyle.None;
            Listado.CellBorderStyle = DataGridViewCellBorderStyle.None;
            Listado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Listado.RowHeadersVisible = false;

            


            DataGridViewCellStyle cabecera = new DataGridViewCellStyle();
            cabecera.BackColor = Color.FromArgb(29, 29, 29);
            cabecera.ForeColor = Color.White;
            cabecera.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Listado.ColumnHeadersDefaultCellStyle = cabecera;

        }


        public static object Decimales(TextBox cajaTexto, KeyPressEventArgs e) {

            if ((e.KeyChar == '.') || (e.KeyChar == ',')) {

                //  comvierte la coma en punto  video agregar cargo min 25
                e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            }

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else if ((e.KeyChar == ',') && (~cajaTexto.Text.IndexOf(",")) != 0)
            {
                e.Handled = true;
            }

            else if (e.KeyChar == '.')
            {
                e.Handled = false;

            }


            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }

            else {
                e.Handled = true;
            }

            return null;

        }

    }
}
