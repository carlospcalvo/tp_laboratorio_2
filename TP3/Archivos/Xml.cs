using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Permite guardar un objeto T en un archivo XML.
        /// </summary>
        /// <param name="archivo"> Nombre del archivo, puede incluir directorio. </param>
        /// <param name="datos"> Objeto a guardar. </param>
        /// <returns> Si se guardó el archivo exitosamente, devuelve true, caso contrario false. </returns>
        public bool Guardar(string archivo, T datos)
        {
            bool aux = false;
            Encoding codificacion = Encoding.UTF8;

            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(archivo, codificacion))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));

                    serializador.Serialize(escritor, datos);
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
        /// Permite generar un objeto a partir de la lectura de un archivo XML.
        /// </summary>
        /// <param name="archivo"> Nombre del archivo, puede incluir el directorio </param>
        /// <param name="datos"> Variable donde se guardará la información leída. </param>
        /// <returns> Si se leyó el archivo exitosamente, devuelve true, caso contrario false. </returns>
        public bool Leer(string archivo, out T datos)
        {
            datos = default;
            bool aux = false;
            Encoding codificacion = Encoding.UTF8;

            try
            {
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));

                    datos = (T)serializador.Deserialize(lector);
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
