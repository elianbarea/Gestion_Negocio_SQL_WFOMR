using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejericioprueba
{
    class Articulo
    {
        
        private string Cod_articulo;
        private string Nombre;
        private string Descripcion;
        private string Marca;
        private string Categoria;
        private string Imagen;
        private int Precio;

        public string cod_articulo
        {
            get {return Cod_articulo; }
            set { Cod_articulo=value; } 
        }
        public string nombres
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public string descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string categoria
        {
            get { return categoria; }
            set { categoria= value; }
        }
        public string imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        public string precio
        {
            get { return precio; }
            set { precio = value; }
        }








    }
}
