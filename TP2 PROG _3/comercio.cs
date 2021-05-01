using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using TP2_PROG_3;



namespace TP_PROG_3
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
                dgvArticulos.Columns["Imagen"].Visible = false;
                cargarImagen(ListarArticulo[0].Imagen);
                 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
          

        }
        public void cargarImagen(string imagen)
        {
            imagenn.Load(imagen);
        }

        

        private void dgvArticulos_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                ///linea 63,lo que esta haciendo es como capturar el elemento seleccionado(explicado en la segunda clase de zoom)
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.Imagen);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            localNegocio negocio= new localNegocio();
           
           
            try
            {
                if(MessageBox.Show("¿De verdad quieres eliminar este articulo? Una vez eliminado no se podra recuperar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
                {
                    negocio.eliminar(seleccionado.Cod_articulo);
                    MessageBox.Show("Eliminado correctamente");
                    comercio_Load(sender, e);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            } 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            localNegocio negocio = new localNegocio();

           /// negocio.buscar(txtbuscar.Text);


        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtbuscar.Text !="")
            {
            ///crea una nueva lista articulo donde va a guardar los articulos que coincidan con la busqueda
            List<Articulo> listaFiltrada = ListarArticulo.FindAll(X => X.Nombre.ToUpper().Contains(txtbuscar.Text.ToUpper()));
            ///vacia el datagridview
            dgvArticulos.DataSource = null;
            ///carga la nueva lista de articulos en el dgv
            dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.Columns["Marca"].Visible = false;
                dgvArticulos.Columns["Categoria"].Visible = false;
                dgvArticulos.Columns["Imagen"].Visible = false;
            }
            else
            {
                ///vacia el datagridview
                dgvArticulos.DataSource = null;
                ///carga la nueva lista de articulos en el dgv
                dgvArticulos.DataSource = ListarArticulo;
                dgvArticulos.Columns["Marca"].Visible = false;
                dgvArticulos.Columns["Categoria"].Visible = false;
                dgvArticulos.Columns["Imagen"].Visible = false;
            }

        }

        private void btnBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                ///crea una nueva lista articulo donde va a guardar los articulos que coincidan con la busqueda
                List<Articulo> listaFiltrada = ListarArticulo.FindAll(X => X.Nombre.ToUpper().Contains(txtbuscar.Text.ToUpper()));
                ///vacia el datagridview
                dgvArticulos.DataSource = null;
                ///carga la nueva lista de articulos en el dgv
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.Columns["Marca"].Visible = false;
                dgvArticulos.Columns["Categoria"].Visible = false;
                dgvArticulos.Columns["Imagen"].Visible = false;
            }
            else
            {
                ///vacia el datagridview
                dgvArticulos.DataSource = null;
                ///carga la nueva lista de articulos en el dgv
                dgvArticulos.DataSource = ListarArticulo;
                dgvArticulos.Columns["Marca"].Visible = false;
                dgvArticulos.Columns["Categoria"].Visible = false;
                dgvArticulos.Columns["Imagen"].Visible = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
           
        }
    }
}
