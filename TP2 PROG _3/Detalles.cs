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
using TP_PROG_3;
using TP2_PROG_3;
using TP2_PROG__3;


namespace TP2_PROG__3
{
    public partial class Detalles : Form
    {
        public Articulo arti;
        public Detalles()
        {
            InitializeComponent();
        }
        public Detalles(Articulo articulo)
        {
            InitializeComponent();
            this.arti = articulo;
            Text = "Detalles de articulo";
        }
        private void Detalles_Load(object sender, EventArgs e)
        {
            localNegocio negocio = new localNegocio();
            
            gbDetalle.Enabled = false;
            if (arti != null)
            {
                ///marca
                cmbMarcaD.DataSource = negocio.listarmarca();
                cmbMarcaD.ValueMember = "Id";
                cmbMarcaD.DisplayMember = "descripcion";
                ///categoria
                cmbCategoriaD.DataSource = negocio.listarcategoria();
                cmbCategoriaD.ValueMember = "Id";
                cmbCategoriaD.DisplayMember = "descripcion";

                txtNombreD.Text = arti.Nombre;
                txtDescripcionD.Text = arti.Descripcion;
                txtImagenD.Text = arti.Imagen;
                txtPrecioD.Text = arti.Precio.ToString();
                txtCodigoD.Text = arti.Cod_articulo;
                cmbMarcaD.SelectedValue = arti.Marca.Id;
                cmbCategoriaD.SelectedValue = arti.Categoria.Id;
                cargarImagen(arti.Imagen);
                

            }




        }
        public void cargarImagen(string imagen)
        {
            try
            {
                    ptbImagenD.Load(imagen);
            }
            catch (Exception)
            {

                cargarImagen("https://infomundojuegos.files.wordpress.com/2013/04/image2s.jpeg");
            }
          
        }
    }
}
