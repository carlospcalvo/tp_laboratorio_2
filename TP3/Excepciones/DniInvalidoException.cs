using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Excepción lanzada en caso de que el numero de DNI de una persona y su nacionalidad no se correspondan.
        /// </summary>
        public DniInvalidoException() : base("DNI invalido.")
        {
        }

        /// <summary>
        /// Excepción lanzada en caso de que el numero de DNI de una persona y su nacionalidad no se correspondan.
        /// </summary>
        /// <param name="e"> Excepción. </param>
        public DniInvalidoException(Exception e) : base(e.Message)
        {
        }

        /// <summary>
        /// Excepción lanzada en caso de que el numero de DNI de una persona y su nacionalidad no se correspondan.
        /// </summary>
        /// <param name="mensaje"> Mensaje personalizado de excepción. </param>
        public DniInvalidoException(string mensaje) : base(mensaje)
        {
        }
        /// <summary>
        /// Excepción lanzada en caso de que el numero de DNI de una persona y su nacionalidad no se correspondan.
        /// </summary>
        /// <param name="mensaje"> Mensaje personalizado de excepción. </param>
        /// <param name="e"> Excepción. </param>
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {
        }
    }
}
