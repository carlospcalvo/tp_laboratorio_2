using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public class Persona
    {
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;

        /// <summary>
        /// get, set: Retorna o asigna el Apellido de la Persona.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {

                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// get, set: Retorna o asigna el Nombre de la Persona.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// get, set: retorna o asigna el DNI de la Persona.
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// get, set: retorna o asigna la Nacionalidad de la Persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// set: Asigna el DNI de la Persona.
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor parametrizado, permite asignar nombre, apellido y nacionalidad de la persona.
        /// </summary>
        /// <param name="nombre"> Nombre de la persona. </param>
        /// <param name="apellido"> Apellido de la persona. </param>
        /// <param name="nacionalidad"> Nacionalidad de la persona. </param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado, permite asignar nombre, apellido, DNI y nacionalidad de la persona.
        /// </summary>
        /// <param name="nombre"> Nombre de la persona. </param>
        /// <param name="apellido"> Apellido de la persona. </param>
        /// <param name="dni"> DNI de la persona. (int) </param>
        /// <param name="nacionalidad"> Nacionalidad de la persona. </param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }

        /// <summary>
        /// Constructor parametrizado, permite asignar nombre, apellido, DNI y nacionalidad de la persona.
        /// </summary>
        /// <param name="nombre"> Nombre de la persona. </param>
        /// <param name="apellido"> Apellido de la persona. </param>
        /// <param name="dni"> DNI de la persona. (string) </param>
        /// <param name="nacionalidad"> Nacionalidad de la persona. </param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        /// <summary>
        /// Hace públicos los datos de la persona en forma de string.
        /// </summary>
        /// <returns> String conteniendo los datos de la persona. </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("Nacionalidad: {0}\n", this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Permite validar que el número de DNI corresponda a la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad de la persona. </param>
        /// <param name="dato"> DNI a validar. (int) </param>
        /// <returns> Devuelve -1 si el DNI no es válido, caso contrario retorna el DNI. </returns>
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dni;

            if ((dato >= 1 && dato <= 99999999))
            {
                if (dato < 90000000 && nacionalidad == ENacionalidad.Argentino)
                {
                    dni = dato;
                }
                else if(dato >= 90000000 && nacionalidad == ENacionalidad.Extranjero)
                {
                    dni = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else //si el dato es un numero mayor a 100.000.000 o menor a 1 lanza excepción
            {
                throw new NacionalidadInvalidaException("DNI inválido.");
            }

            return dni;
        }

        /// <summary>
        /// Permite validar que el número de DNI corresponda a la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad de la persona. </param>
        /// <param name="dato"> DNI a validar. (string) </param>
        /// <returns> Devuelve -1 si el DNI no es válido, caso contrario retorna el DNI. </returns>
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if(int.TryParse(dato, out int dni))
            {
                dni = ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException("DNI inválido.");
            }
            
            return dni;
        }
        
        /// <summary>
        /// Permite validar que el nombre o apellido ingresado este compuesto solo por letras.
        /// </summary>
        /// <param name="dato"> Nombre o apellido a validar. (string) </param>
        /// <returns> Devuelve un string vacio si no es válido, caso contrario retorna la cadena pasada por parametro]. </returns>
        string ValidarNombreApellido(string dato)
        {
            string aux;
            bool flag = false;
            
            foreach(char c in dato)
            {
                if(char.IsLetter(c) || char.IsWhiteSpace(c))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            if(flag == true)
            {
                aux = dato;
            }
            else
            {
                throw new Exception("Nombre o apellido inválido.");
            }


            return aux;
        }

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

    }
}

