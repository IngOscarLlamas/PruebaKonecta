using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.PRESENTACION
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panelBienvenida.Dock = DockStyle.Fill;
        }


        private void btnVentas_Click_1(object sender, EventArgs e)
        {
            Ventas control = new Ventas();

            PanelPrincipal.Controls.Clear(); // limpiar el panel de los elementos que contenga
            control.Dock = DockStyle.Fill;
            PanelPrincipal.Controls.Add(control);
         
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos control = new Productos();
            PanelPrincipal.Controls.Clear(); // limpiar el panel de los elementos que contenga
            control.Dock = DockStyle.Fill;
            PanelPrincipal.Controls.Add(control);
        }
    }
}
