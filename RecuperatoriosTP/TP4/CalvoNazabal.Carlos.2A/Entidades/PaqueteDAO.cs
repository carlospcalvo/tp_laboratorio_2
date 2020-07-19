using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        /// <summary>
        /// Constructor: Asigna al SqlConnection el string de conexión y configura el SqlCommand 
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection("Server = localhost\\SQLEXPRESS; Database=master;Trusted_Connection=True;");
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }

        /// <summary>
        /// Inserta un paquete a la base de datos SQL
        /// </summary>
        /// <param name="p"> Paquete a insertar </param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool aux = true;

            try
            {
                int filasInsertadas = 0;
                
                comando.CommandText = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) VALUES (" + "'" + p.DireccionEntrega + "','" + p.TrackingID +"','" + "Carlos Calvo Nazabal')";

                conexion.Open();

                filasInsertadas = comando.ExecuteNonQuery();

                if (filasInsertadas == 0)
                {
                    aux = false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return aux;
        }

    }
}
