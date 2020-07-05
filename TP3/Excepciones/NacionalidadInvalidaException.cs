using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Excepcion lanzada al querer crear un objeto derivado de Persona si el DNI no está entre 90 millones y 99.999.999 y su nacionalidad es argentina,
        /// o si el DNI está entre 1 y 89.999.999 y su nacionalidad es extranjera.
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no se condice con el numero de DNI.")
        {
        }
        /// <summary>
        /// Excepcion lanzada al querer crear un objeto derivado de Persona si el DNI no está entre 90 millones y 99.999.999 y su nacionalidad es argentina,
        /// o si el DNI está entre 1 y 89.999.999 y su nacionalidad es extranjera.
        /// </summary>
        /// <param name="mensaje"> Mensaje que mostrará la excepción </param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {
        }

    }
}
