using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno() : base()
        {
        }

        /// <summary>
        /// Constructor parametrizado, permite crear una instancia de Alumno definiendo su legajo, nombre, apellido, DNI, nacionalidad y la clase que toma. 
        /// </summary>
        /// <param name="id"> Legajo del Alumno. </param>
        /// <param name="nombre"> Nombre del Alumno. </param>
        /// <param name="apellido"> Apellido del Alumno. </param>
        /// <param name="dni"> DNI del Alumno. </param>
        /// <param name="nacionalidad"> Nacionalidad del Alumno. </param>
        /// <param name="claseQueToma"> Clases que toma el Alumno. </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor parametrizado, permite crear una instancia de Alumno definiendo 
        /// su legajo, nombre, apellido, DNI, nacionalidad, la clase que toma y su estado de cuenta. 
        /// </summary>
        /// <param name="id"> Legajo del Alumno. </param>
        /// <param name="nombre"> Nombre del Alumno. </param>
        /// <param name="apellido"> Apellido del Alumno. </param>
        /// <param name="dni"> DNI del Alumno. </param>
        /// <param name="nacionalidad"> Nacionalidad del Alumno. </param>
        /// <param name="claseQueToma"> Clases que toma el Alumno. </param>
        /// <param name="estadoCuenta"> Estado de cuenta del Alumno. </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Permite obtener la clase en la que toma parte el alumno.
        /// </summary>
        /// <returns> String con la clase que toma el alumno. </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("TOMA CLASE DE {0}\n", this.claseQueToma);

            return sb.ToString();
        }

        /// <summary>
        /// Permite obtener un string con todos los datos del alumno.
        /// </summary>
        /// <returns> String con todos los datos del alumno. </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("ESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Permite hacer públicos los datos de un alumno.
        /// </summary>
        /// <returns> string con los datos de un alumno. </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Permite saber si un alumno toma una clase determinada y si no es deudor.
        /// </summary>
        /// <param name="alumno"> Alumno a evaluar. </param>
        /// <param name="clase"> Clase a evaluar. </param>
        /// <returns> Retorna true si el alumno participa de la clase y no es deudor, caso contrario retorna false. </returns>
        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            return (alumno.claseQueToma == clase && alumno.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Permite saber si un alumno no toma una clase determinada o si es deudor.
        /// </summary>
        /// <param name="alumno"> Alumno a evaluar. </param>
        /// <param name="clase"> Clase a evaluar. </param>
        /// <returns> Retorna true si el alumno no participa de la clase o es deudor, caso contrario retorna false. </returns>
        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            return !(alumno != clase);
        }

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}
