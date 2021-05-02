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
                cmbMarca.SelectedValue = arti.Marca;
                cmbCategoria.SelectedValue = arti.Categoria;

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

        private void btnAgregar2_Click(object sender, EventArgs e)
        {

            localNegocio negocio = new localNegocio();

            try
            {
                ///error aca
                if (arti ==null )
                {
                    Articulo A = new Articulo();

                    A.Nombre = txtNombre.Text;
                    A.Descripcion = txtDescripcion.Text;
                    A.Marca = (Marca)cmbMarca.SelectedItem;
                    A.Imagen = txtImagen.Text;
                    A.Categoria = (Categoria)cmbCategoria.SelectedItem;
                    A.Precio = Convert.ToDecimal(txtPrecio.Text);
                    A.Cod_articulo = txtCodigo.Text;

                    negocio.agregar(A);
                    MessageBox.Show("Agregado perfectamente");
                }
                else
                {
                    negocio.modificar(arti);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            

        }
    }
}
