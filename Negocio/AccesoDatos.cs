using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    class AccesoDatos
    {

            private SqlConnection conexion;
            private SqlCommand comando;
            private SqlDataReader lector;

            public AccesoDatos()//accede a la DB
            {

            ///conexion = new SqlConnection("data source=DESKTOP-UGVRLNH\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");
            conexion = new SqlConnection("data source=DESKTOP-CEKNLMQ\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");
            comando = new SqlCommand();
            }

            public void setearConsulta(string consulta)//setea la consulta
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
             
            }

            public void ejecutarlectura()
            {

                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
            }

            public void cerrarConexion()
            {
                if (lector != null)
                    lector.Close();
                conexion.Close();
            }

            internal void ejecutarAcion()
            {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();

            }

            public SqlDataReader Lector
            {
                get { return lector; }
            }

            public void AgregarParametro (string nombre, string valor)
        {

            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void AgregarParametrodecimal(string nombre, decimal valor)
        {

            comando.Parameters.AddWithValue(nombre, valor);
        }


    }

}
