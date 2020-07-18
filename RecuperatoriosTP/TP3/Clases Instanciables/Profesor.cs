using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{

    public sealed class Profesor : Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        /// <summary>
        /// Constructor privado por defecto, inicializa la colección clasesDelDia y asigna las clases mediante el método RandomClases().
        /// </summary>
        private Profesor() : base()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases();

        }

        /// <summary>
        /// Constructor por defecto estático, inicializa el atributo random.
        /// </summary>
        static Profesor()
        {
            random = new Random(Environment.TickCount); 
        }

        /// <summary>
        /// Constructor parametrizado, permite crear una instancia de Profesor asignando legajo, nombre, apellido, dni y nacionalidad.
        /// </summary>
        /// <param name="id"> Legajo del profesor. </param>
        /// <param name="nombre"> Nombre del profesor. </param>
        /// <param name="apellido"> Apellido del profesor. </param>
        /// <param name="dni"> DNI del profesor. (string) </param>
        /// <param name="nacionalidad"> Nacionalidad del profesor. </param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad) //: this() 
        {
            Profesor aux = new Profesor();

            this.clasesDelDia = aux.clasesDelDia;
        }

        /// <summary>
        /// Asigna dos clases aleatorias a la colección clasesDelDia.
        /// </summary>
        private void RandomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,4));
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,4));
        }

        /// <summary>
        /// Genera un string con los datos del profesor.
        /// </summary>
        /// <returns> Datos del profesor (string) </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Retorna las clases en las que participa el profesor.
        /// </summary>
        /// <returns> Clases en las que participa el profesor. (string) </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            sb.AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// Publica los datos del profesor en forma de string.
        /// </summary>
        /// <returns> Datos del profesor. (string) </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Permite saber si un profesor da una clase.
        /// </summary>
        /// <param name="i"> Profesor a comparar. </param>
        /// <param name="clase"> Clase a comparar. </param>
        /// <returns> Si alguno de los valores de la colección clasesDelDia del Profesor 
        /// es igual a la clase pasada como parámetro, retorna true. Caso contrario, false.  </returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool aux = false;

            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Permite saber si un profesor no da una clase.
        /// </summary>
        /// <param name="i"> Profesor a comparar. </param>
        /// <param name="clase"> Clase a comparar. </param>
        /// <returns> Si alguno de los valores de la colección clasesDelDia del Profesor 
        /// es distinta a la clase pasada como parámetro, retorna true. Caso contrario, false.  </returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}

