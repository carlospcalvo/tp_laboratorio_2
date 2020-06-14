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

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true, codificacion))
                {
                    sw.WriteLine("<<----------------------------------------------------------------------------->>");
                    sw.WriteLine(datos);
                    sw.WriteLine("<<----------------------------------------------------------------------------->>");
                    sw.Write("Ultima modificacion: ");
                    sw.WriteLine(DateTime.Now);
                }
                aux = true;
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
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

            try
            {
                using (StreamReader sr = new StreamReader(archivo, codificacion))
                {
                    datos = sr.ReadToEnd().ToString();
                }
                aux = true;
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return aux;
        }
    }
}
