using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// get, set: retorna o asigna la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// get, set: retorna o asigna la clase de la jornada.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// get, set: retorna o asigna el profesor de la jornada.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }


        /// <summary>
        /// Constructor por defecto, inicializa la lista de alumnos.
        /// </summary>
        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado, permite crear un objeto Jornada asignando la clase y el profesor.
        /// </summary>
        /// <param name="clase"> Clase a definir. </param>
        /// <param name="instructor"> Profesor a definir. </param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Genera un string con los datos de la jornada.
        /// </summary>
        /// <returns> String con los datos de la jornada. </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            sb.AppendFormat("CLASE DE {0} POR {1}\n", this.clase, this.instructor);
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno a in this.Alumnos)
            {
                sb.Append(a);
            }
            sb.AppendLine("<------------------------------------------------------>");

            return sb.ToString();
        }

        /// <summary>
        /// Permite saber si un alumno pertenece a la lista de alumnos de la jornada.
        /// </summary>
        /// <param name="j"> Jornada a comparar. </param>
        /// <param name="a"> Alumno a comparar. </param>
        /// <returns> Devuelve true si el alumno se encuentra en la lista de alumnos de la jornada, caso contrario devuelve false. </returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool aux = false;

            foreach (Alumno item in j.Alumnos)
            {
                if (item == a)
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Permite saber si un alumno no pertenece a la lista de alumnos de la jornada.
        /// </summary>
        /// <param name="j"> Jornada a comparar. </param>
        /// <param name="a"> Alumno a comparar. </param>
        /// <returns> Devuelve true si el alumno no se encuentra en la lista de alumnos de la jornada, caso contrario devuelve false. </returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Permite agregar un alumno a la lista de alumnos de la jornada si no pertenece a la misma.
        /// </summary>
        /// <param name="j"> Jornada a la que se agregará el alumno. </param>
        /// <param name="a"> Alumno a agregar </param>
        /// <returns> Devuelve un objeto Jornada con el alumno agregado si éste no estaba previamente en la lista de alumnos,
        /// caso contrario devuelve la jornada sin modificar. </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            Jornada aux = j;

            if (j != a)
            {
                aux.Alumnos.Add(a);
            }

            return aux;
        }

        /// <summary>
        /// Permite guardar los datos de una jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"> Jornada a guardar. </param>
        /// <returns> Si se pudo guardar los datos devuelve true, caso contrario false. </returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto aux = new Texto();
            
            return aux.Guardar("Datos.txt", jornada.ToString());
        }

        /// <summary>
        /// Permite leer los contenidos de un archivo de texto.
        /// </summary>
        /// <returns> Devuelve un string con los datos leídos. </returns>
        public static string Leer()
        {
            string path = "Datos.txt";
            Texto aux = new Texto();

            aux.Leer(path, out string lectura);

            return lectura;
        }
    }
}
