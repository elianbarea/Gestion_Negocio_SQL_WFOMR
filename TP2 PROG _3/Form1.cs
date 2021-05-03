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

namespace TP2_PROG__3
{
    public partial class FrmAgregar : Form
    {
        private Articulo arti = null;
        public FrmAgregar()
        {
            InitializeComponent();
        }
        public FrmAgregar(Articulo artiulo)
        {
            InitializeComponent();
            this.arti = artiulo;
            Text = "modificar articulo";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            localNegocio negocio = new localNegocio();

            if (arti != null)
            {
                ///marca
                cmbMarca.DataSource = negocio.listarmarca();
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "descripcion";
                ///categoria
                cmbCategoria.DataSource = negocio.listarcategoria();
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "descripcion";

                txtNombre.Text = arti.Nombre;
                txtDescripcion.Text = arti.Descripcion;
                txtImagen.Text = arti.Imagen;
                txtPrecio.Text = arti.Precio.ToString();
                txtCodigo.Text = arti.Cod_articulo;
                cmbMarca.SelectedValue = arti.Marca.Id;
                cmbCategoria.SelectedValue = arti.Categoria.Id;

            }
            else
            {
                cmbMarca.DataSource = negocio.listarmarca();
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "descripcion";

                cmbCategoria.DataSource = negocio.listarcategoria();
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "descripcion";
            }
                

               


            

        }

        public bool ValidarTextBox()
        {
            if (txtCodigo.Text.Length == 0) return false;
            if (txtNombre.Text.Length == 0) return false;
            if (txtDescripcion.Text.Length == 0) return false;
            if (cmbMarca.SelectedIndex < 0) return false;
            if (cmbCategoria.SelectedIndex < 0) return false;
            if (txtImagen.Text.Length == 0) return false;
            if (txtPrecio.Text.Length == 0) return false;
            return true;
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {

            localNegocio negocio = new localNegocio();

            try
            {
                
                if (ValidarTextBox())
                {


                    if (arti == null) arti = new Articulo();

                    arti.Cod_articulo = txtCodigo.Text;
                    arti.Nombre = txtNombre.Text;
                    arti.Descripcion = txtDescripcion.Text;
                    arti.Marca = (Marca)cmbMarca.SelectedItem;
                    arti.Categoria = (Categoria)cmbCategoria.SelectedItem;
                    arti.Imagen = txtImagen.Text;
                    arti.Precio = Convert.ToDecimal(txtPrecio.Text);

                    if (arti.id == 0) negocio.agregar(arti);

                    else negocio.modificar(arti);

                    this.Close();
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            

        }
    }
}
