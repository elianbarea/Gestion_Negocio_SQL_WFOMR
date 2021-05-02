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
                ///datos.setearConsulta("select Codigo, Nombre, Descripcion,Marca,Categoria, ImagenUrl, Precio from ARTICULOS");
                datos.setearConsulta("select P.Id, P.Codigo,P.Nombre, P.Descripcion, M.Descripcion[Marca], C.Descripcion[Categoria], P.ImagenUrl,P.Precio,M.Id, C.Id from ARTICULOS P, MARCAS M, CATEGORIAS C where P.IdMarca = m.Id AND P.IdCategoria = C.Id");
                datos.ejecutarlectura();

                while (datos.Lector.Read())
                {
                    Articulo ar = new Articulo();
                    ar.Cod_articulo = (string)datos.Lector["Codigo"];
                    ar.Nombre = (string)datos.Lector["Nombre"];

                    ar.Marca = new Marca();
                    ar.Marca.descripcion = (string)datos.Lector["Marca"];

                    ar.Categoria = new Categoria();
                    ar.Categoria.descripcion = (string)datos.Lector["Categoria"];
                    ar.Precio = (decimal)datos.Lector["Precio"];
                    ar.Imagen = (string)datos.Lector["ImagenUrl"];
                    ar.Descripcion = (string)datos.Lector["Descripcion"];
                    

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
        public void listarmarcas()
        {
            
        }
        public List<Marca> listarmarca()
        {
            List<Marca> marca = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from MARCAS");
                datos.ejecutarlectura();

                while (datos.Lector.Read())
                {
                    Marca m = new Marca();
                    m.descripcion = (string)datos.Lector["Descripcion"];
                    m.Id = (int)datos.Lector["Id"];

                    marca.Add(m);
                
                }
                return marca;

                }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public List<Categoria> listarcategoria()
        {
            List<Categoria> categoria = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from CATEGORIAS");
                datos.ejecutarlectura();

                while (datos.Lector.Read())
                {
                    Categoria m = new Categoria ();
                    m.descripcion = (string)datos.Lector["Descripcion"];
                    m.Id = (int)datos.Lector["Id"];

                    categoria.Add(m);

                }
                return categoria;

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
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from ARTICULOS where codigo=@id");
                datos.AgregarParametro("@Id", id);
                datos.ejecutarAcion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
                datos = null;
            }
        }

        public void agregar(Articulo ar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values(@codigo,@nombre,@descripcion,@IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.AgregarParametro("@codigo",ar.Cod_articulo) ;
                datos.AgregarParametro("@nombre",ar.Nombre);
                datos.AgregarParametro("@descripcion",ar.Descripcion);
                datos.AgregarParametro("@IdMarca", Convert.ToString( ar.Marca.Id));
                datos.AgregarParametro("@IdCategoria",Convert.ToString(ar.Categoria.Id));
                datos.AgregarParametro("@ImagenUrl",ar.Imagen);
                datos.AgregarParametro("@Precio", Convert.ToString(ar.Precio));
                datos.ejecutarAcion();
                



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
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            ///consulta de prueba
            datos.setearConsulta("update from ARTICULOS set Precio= " + articulo.Precio);
            datos.ejecutarlectura();


        }


    }


        
        



    }



