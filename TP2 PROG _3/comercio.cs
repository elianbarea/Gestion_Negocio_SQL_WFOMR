using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TP2_PROG__3
{
    public partial class comercio : Form
    {
        private List<Articulo> ListarArticulo;
        public comercio()
        {
            InitializeComponent();
        }

        private void comercio_Load(object sender, EventArgs e)
        {
            localNegocio localnegocio = new localNegocio();

            try
            { 
                ListarArticulo = localnegocio.listar();
                dgvArticulos.DataSource = ListarArticulo;
                dgvArticulos.Columns["Marca"].Visible = false;
                dgvArticulos.Columns["Categoria"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
