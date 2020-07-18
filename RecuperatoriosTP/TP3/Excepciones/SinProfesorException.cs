using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Excepcion lanzada al no haber profesores que den una determinada clase (i.e. que posean el atributo clasesDelDia correspondiente)
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {
        }
    }
}
