using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepción lanzada en caso de haber un error en la escritura o lectura de archivos.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base()
        {
        }

    }
}
