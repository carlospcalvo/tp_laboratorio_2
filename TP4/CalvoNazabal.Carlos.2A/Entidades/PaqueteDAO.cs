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

        static PaqueteDAO()
        {
            conexion = new SqlConnection("Server = localhost\\SQLEXPRESS; Database=master;Trusted_Connection=True;");
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }
        public static bool Insertar(Paquete p)
        {
            bool aux = true;

            try
            {
                int filasAfectadas = 0;
                
                comando.CommandText = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) VALUES (" + "'" + p.DireccionEntrega + "','" + p.TrackingID +"','" + "Carlos Calvo Nazabal')";

                conexion.Open();

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    aux = false;
                }
            }
            catch(Exception)
            {
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
