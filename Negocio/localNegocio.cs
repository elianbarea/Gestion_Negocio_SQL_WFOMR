using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class localNegocio
    {

        public List<Articulo> listar()
        {
            
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("select Codigo, Nombre, Descripcion, ImagenUrl, Precio from ARTICULOS");
                datos.ejecutarlectura();

                while (datos.Lector.Read())
                {
                    Articulo ar = new Articulo();
                    ar.Cod_articulo = (string)datos.Lector["Codigo"];
                    ar.Nombre = (string)datos.Lector["Nombre"];
                    ar.Descripcion = (string)datos.Lector["Descripcion"];
                    ar.Precio = (decimal)datos.Lector["Precio"];
                    ar.Imagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(ar);

                    
                   

                }
                    return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }




            

        }

        public void eliminar(string id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id= " + id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        



    }
}

