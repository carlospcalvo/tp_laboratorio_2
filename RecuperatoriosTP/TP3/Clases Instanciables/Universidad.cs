using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// get, set: retorna o asigna la lista de Alumnos.
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
        /// get, set: retorna o asigna la lista de Jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// get, set: retorna o asigna la lista de Profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// get, set: retorna o asigna una jornada en el índice indicado de la lista de jornadas.
        /// </summary>
        /// <param name="i"> Índice de jornada al que se quiere acceder. </param>
        /// <returns> Jornada del índice especificado. </returns>
        public Jornada this[int i]
        {
            get
            {
                if(i >= 0 && i < this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    throw new Exception("Índice inválido.");
                }
            }

            set
            {
                if(i >= 0 && i <= this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
                else
                {
                    throw new Exception("Índice inválido.");
                }
            }
        }

        /// <summary>
        /// Constructor por defecto, inicializa todas las colecciones.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }

        /// <summary>
        /// Permite generar un string con los datos de la Universidad.
        /// </summary>
        /// <param name="uni"> Objeto Universidad cuyos datos se quiere obtener. </param>
        /// <returns> string conteniendo la información de la Universidad. </returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada item in uni.Jornadas)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Permite publicar los datos de la Universidad.
        /// </summary>
        /// <returns> string conteniendo los datos de la Universidad. </returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Permite saber si un alumno pertenece a la universidad.
        /// </summary>
        /// <param name="g"> Universidad a comparar. </param>
        /// <param name="a"> Alumno a comparar. </param>
        /// <returns> Si el alumno está en la lista de alumnos de la universidad devuelve true, caso contrario false. </returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool aux = false;

            foreach (Alumno item in g.Alumnos)
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
        /// Permite saber si un alumno no pertenece a la universidad.
        /// </summary>
        /// <param name="g"> Universidad a comparar. </param>
        /// <param name="a"> Alumno a comparar. </param>
        /// <returns> Si el alumno no está en la lista de alumnos de la universidad devuelve true, caso contrario false. </returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Permite saber si un profesor pertenece a la universidad.
        /// </summary>
        /// <param name="g"> Universidad a comparar. </param>
        /// <param name="a"> Profesor a comparar. </param>
        /// <returns> Si el profesor está en la lista de profesores de la universidad devuelve true, caso contrario false. </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool aux = false;

            foreach(Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Permite saber si un profesor no pertenece a la universidad.
        /// </summary>
        /// <param name="g"> Universidad a comparar. </param>
        /// <param name="a"> Profesor a comparar. </param>
        /// <returns> Si el profesor no está en la lista de profesores de la universidad devuelve true, caso contrario false. </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Permite saber si hay profesores que puedan dar una clase determinada.
        /// </summary>
        /// <param name="u"> Universidad a comparar. </param>
        /// <param name="clase"> Clase a comparar. </param>
        /// <returns> Devuelve el primer profesor que puede dar la clase, caso contrario lanza la excepción SinProfesorException. </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor aux = default; 
            bool flag = false;
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                {
                    flag = true;
                    aux = p;
                    break;
                }
            }

            if(flag == false)
            {
                throw new SinProfesorException();
            }
            
            return aux;
        }

        /// <summary>
        /// Permite obtener el primer profesor que no da una clase determinada.
        /// </summary>
        /// <param name="u"> Universidad a comparar. </param>
        /// <param name="clase"> Clase a comparar. </param>
        /// <returns> Devuelve el primer profesor que no puede dar la clase, caso contrario lanza la excepción SinProfesorException. </returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor aux = default; 
            bool flag = false;

            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    aux = item;
                    flag = true;
                    break;
                }
            }

            if (flag == false)
            {
                throw new SinProfesorException();
            }

            return aux;
        }

        /// <summary>
        /// Permite agregar un alumno a la lista de alumnos de una universidad si este no pertenece aún.
        /// </summary>
        /// <param name="u"> Universidad a la que se agregará el alumno. </param>
        /// <param name="a"> Alumno a agregar </param>
        /// <returns> En caso de que el alumno no perteneciera aún a la universidad, 
        /// devuelve una instancia de Universidad con el alumno agregado.
        /// Caso contrario lanza la excepción AlumnoRepetidoException. </returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            Universidad aux = u;

            if (u.Alumnos != null)
            {
                if(u != a)
                {
                    aux.alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }

            return aux;
        }

        /// <summary>
        /// Permite agregar un profesor a la lista de profesores de la universidad si no pertenece a ésta.
        /// </summary>
        /// <param name="u"> Universidad a la que se agregará el profesor. </param>
        /// <param name="i"> Profesor a agregar. </param>
        /// <returns> Devuelve una nueva instancia de Universidad con el profesor añadido 
        /// en caso de que no formara parte de la lista de profesores previamente.
        /// Caso contrario devuelve la instancia anterior sin modificaciones. </returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            Universidad aux = u;
            
            if (u.Instructores != null)
            {
                if(u != i)
                {
                    u.Instructores.Add(i);
                }
                else
                {
                    throw new Exception("El profesor ya existe!");
                }

            }

            return aux;
        }

        /// <summary>
        /// Permite agregar una jornada a la lista de jornadas de la universidad si no pertenece a ésta.
        /// </summary>
        /// <param name="u"> Universidad a la que se agregará el profesor. </param>
        /// <param name="clase"> Jornada a agregar. </param>
        /// <returns> Devuelve una nueva instancia de Universidad con la jornada añadida 
        /// en caso de que no formara parte de la lista de jornadas previamente, 
        /// que haya alumnos que tomen esa clase y que se le pueda asignar un profesor.
        /// Caso contrario devuelve la instancia anterior sin modificaciones. </returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Universidad aux = u;
            Jornada jornada = new Jornada();
            bool flag = false;

            jornada.Clase = clase;
            jornada.Instructor = (u == clase);

            if(u.Alumnos != null)
            {
                foreach (Alumno a in u.Alumnos)
                {
                    if (a == clase)
                    {
                        flag = true;
                        jornada.Alumnos.Add(a);
                    }
                }
            }
            /*
             * Si hay alumnos que toman la clase se agrega la jornada,
             * caso contrario no se agrega (la consigna no especifica este caso,
             * lo hice de esta manera dado que una clase no puede darse sin alumnos).
            */
            if (flag == true) 
            {
                aux.Jornadas.Add(jornada);
            }

            return aux;
        }

        /// <summary>
        /// Permite guardar los datos de un objeto Universidad en un archivo XML.
        /// </summary>
        /// <param name="uni"> Objeto Universidad a guardar. </param>
        /// <returns> Retorna true si se pudo guardar, caso contrario retorna false. </returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> aux = new Xml<Universidad>();

            return aux.Guardar("Datos.xml", uni); 
        }

        /// <summary>
        /// Permite generar un objeto Universidad con los datos leidos de un archivo XML.
        /// </summary>
        /// <returns> Retorna un objeto Universidad en caso de haber leído el archivo correctamente, caso contrario retorna false. </returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            xml.Leer("Datos.xml", out Universidad aux);

            return aux; 
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
