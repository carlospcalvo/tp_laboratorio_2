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
        /// get: retorna la lista de Alumnos.
        /// set: setea la lista de Alumnos.
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
        /// get: retorna la lista de Jornadas.
        /// set: setea la lista de Jornadas.
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
        /// get: retorna la lista de Profesores.
        /// set: setea la lista de Profesores.
        /// </summary>
        public List<Profesor> Profesores
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
        /// get: permite obtener de la colección de jornadas la jornada del índice indicado.
        /// set: permite modificar en la colección de jornadas la jornada del índice indicado.
        /// </summary>
        /// <param name="i"> Índice de jornada al que se quiere acceder. </param>
        /// <returns> Jornada del índice especificado. </returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }

            set
            {
                this.jornada[i] = value;
            }
        }

        /// <summary>
        /// Constructor por defecto, inicializa todas las colecciones.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Permite generar un string con los datos de la Universidad.
        /// </summary>
        /// <param name="uni"> Objeto Universidad cuyos datos se quiere obtener. </param>
        /// <returns> string conteniendo la información de la Universidad. </returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada item in uni.jornada)
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
            return Universidad.MostrarDatos(this);
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

            foreach (Alumno item in g.alumnos)
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

            foreach (Alumno item in g.alumnos)
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
            foreach (Profesor p in u.profesores)
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
            Profesor aux = new Profesor(-1, "", "", "-1", Clases_Abstractas.Persona.ENacionalidad.Argentino);

            foreach (Jornada item in u.Jornadas)
            {
                if (item.Clase != clase)
                {
                    if (item.Instructor != null)
                    {
                        aux = item.Instructor;
                    }
                }
            }

            if (aux.Dni == -1)
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

            if (u.alumnos != null)
            {
                foreach (Alumno item in u.alumnos)
                {
                    if (item == a)
                    {
                        throw new AlumnoRepetidoException();
                    }
                }
            }

            aux.alumnos.Add(a);

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
            bool existe = false;
            if (u.profesores != null)
            {
                foreach (Profesor item in u.profesores)
                {
                    if (item == i)
                    {
                        existe = true;
                        break;
                    }
                }

            }

            if (existe == false)
            {
                aux.profesores.Add(i);
            }
            else
            {
                Console.WriteLine("El profesor ya pertenece a la universidad.");
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

            if (u.profesores != null)
            {
                if(u.profesores.Count() <= 0)
                {
                    throw new SinProfesorException();
                }
                else
                {
                    jornada.Instructor = (u == clase);
                }
            }

            if(u.alumnos != null)
            {
                foreach (Alumno a in u.alumnos)
                {
                    if (a == clase)
                    {
                        flag = true;
                        jornada.Alumnos.Add(a);
                    }
                }
            }
            
            if(flag == true)
            {
                aux.jornada.Add(jornada);
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
        /// Permite leer los datos de un archivo XML y generar un objeto Universidad a partir de los mismos.
        /// </summary>
        /// <returns> Retorna un objeto Universidad en caso de haber leído el archivo correctamente, caso contrario retorna false. </returns>
        public static Universidad Leer()
        {
            Universidad aux;
            Xml<Universidad> xml = new Xml<Universidad>();

            xml.Leer("Datos.xml", out aux);

            return aux; 
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }
    }
}
