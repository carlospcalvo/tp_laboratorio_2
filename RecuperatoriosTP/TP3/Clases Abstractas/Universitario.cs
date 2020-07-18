using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario() : base()
        {
        }

        /// <summary>
        /// Constructor parametrizado, permite definir legajo, nombre, apellido, dni y nacionalidad de un obejto Universitario.
        /// </summary>
        /// <param name="legajo">  Legajo del Universitario. </param>
        /// <param name="nombre">  Nombre del Universitario. </param>
        /// <param name="apellido">  Apellido del Universitario. </param>
        /// <param name="dni">  DNI del Universitario. </param>
        /// <param name="nacionalidad">  Nacionalidad del Universitario. </param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Retorna un string con los datos del universitario.
        /// </summary>
        /// <returns> string con los datos del universitario. </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Permite comparar dos universitarios, estos son iguales si son del mismo tipo y su legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1"> Primer Universitario a comparar. </param>
        /// <param name="pg2"> Segundo Universitario a comparar. </param>
        /// <returns> Retorna true si son del mismo tipo y tienen el mismo legajo o DNI, caso contrario retorna false. </returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.Dni == pg2.Dni));
        }

        /// <summary>
        /// Permite comparar dos universitarios, estos son distintos si son de distinto tipo o su legajo y DNI son distintos.
        /// </summary>
        /// <param name="pg1"> Primer Universitario a comparar. </param>
        /// <param name="pg2"> Segundo Universitario a comparar. </param>
        /// <returns> Retorna true si son de distinto tipo o su legajo y DNI son distintos, caso contrario retorna false. </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Permite saber si dos objetos Universitario son iguales.
        /// </summary>
        /// <param name="obj"> Objeto a comparar con el objeto actual. </param>
        /// <returns> Devuelve true si son iguales, caso contrario retorna false. </returns>
        public override bool Equals(object obj)
        {
            bool aux = false;

            if(obj is Universitario)
            {
                aux = this == (Universitario)obj;
            }

            return aux;
        }

    }
}
