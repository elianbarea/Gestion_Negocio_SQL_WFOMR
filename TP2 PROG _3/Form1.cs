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

        public FrmAgregar()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            localNegocio negocio = new localNegocio();

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
            catch (Exception ex)
            {

                throw ex;
            }

            

        }
    }
}
