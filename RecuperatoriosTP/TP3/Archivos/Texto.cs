using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Permite guardar información en un archivo de texto.
        /// </summary>
        /// <param name="archivo"> Nombre del archivo, puede incluir o no el directorio. </param>
        /// <param name="datos"> Información que se desea guardar. </param>
        /// <returns> Retorna "true" si se pudo guardar el archivo, falso si hubo un error. </returns>
        public bool Guardar(string archivo, string datos)
        {
            bool aux = false;
            Encoding codificacion = Encoding.UTF8;
            StreamWriter sw = new StreamWriter(archivo, true, codificacion);

            try
            {
                using (sw)
                {
                    sw.WriteLine("<<----------------------------------------------------------------------------->>");
                    sw.WriteLine(datos);
                    sw.WriteLine("<<----------------------------------------------------------------------------->>");
                    sw.Write("Ultima modificacion: ");
                    sw.WriteLine(DateTime.Now);
                }
                aux = true;
            }
            catch (ArchivosException)
            {
                aux = false;
            }
            finally
            {
                sw.Close();
            }

            return aux;
        }

        /// <summary>
        /// Permite leer un archivo de texto.
        /// </summary>
        /// <param name="archivo"> Nombre del archivo, puede incluir o no el directorio. </param>
        /// <param name="datos"> Variable donde se guardará la información leída del archivo. </param>
        /// <returns> Retorna "true" si se pudo leer el archivo, falso si hubo un error. </returns>
        public bool Leer(string archivo, out string datos)
        {
            datos = null;
            bool aux = false;
            Encoding codificacion = Encoding.UTF8;
            StreamReader sr = new StreamReader(archivo, codificacion);

            try
            {
                using (sr)
                {
                    datos = sr.ReadToEnd().ToString();
                }
                aux = true;
            }
            catch (ArchivosException)
            {
                aux = false;
            }
            finally
            {
                sr.Close();
            }

            return aux;
        }
    }
}
