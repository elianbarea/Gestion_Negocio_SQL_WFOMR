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
using TP_PROG_3;
using TP2_PROG_3;
using TP2_PROG__3;



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

            cargarGrilla();

        }

        public void cargarGrilla()
        {
            localNegocio localnegocio = new localNegocio();
            try
            {
                ListarArticulo = localnegocio.listar();
                dgvArticulos.DataSource = ListarArticulo;
                /*dgvArticulos.Columns["Marca"].Visible = false;
                dgvArticulos.Columns["Categoria"].Visible = false;*/
                dgvArticulos.Columns["Imagen"].Visible = false;
                dgvArticulos.Columns["Id"].Visible = false;
                cargarImagen(ListarArticulo[0].Imagen);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form formu = new FrmAgregar();
            formu.ShowDialog();
            cargarGrilla();



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

                cargarImagen("https://infomundojuegos.files.wordpress.com/2013/04/image2s.jpeg");
            }
           
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            localNegocio negocio= new localNegocio();
           
           
            try
            {
                if(MessageBox.Show("¿De verdad quieres eliminar este articulo? Una vez eliminado no se podra recuperar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
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


        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            FrmAgregar mod = new FrmAgregar(seleccionado);
            mod.ShowDialog();
            cargarGrilla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            Detalles detalle = new Detalles(seleccionado);
            detalle.ShowDialog();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> arti;

            try
            {
                if (txtbuscar.Text == "") arti = ListarArticulo;
                else arti = ListarArticulo.FindAll(PAPA => PAPA.Nombre.ToLower().Contains(txtbuscar.Text.ToLower())); dgvArticulos.DataSource = arti;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}
