using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Excepción lanzada si se trata de agregar un alumno ya existente en una lista de alumnos.
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {
        }
    }
}
