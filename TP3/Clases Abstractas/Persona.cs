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
        /// get: Retorna el Apellido de la Persona.
        /// set: Chequea que el Apellido que se le quiera dar a la Persona tenga caracteres válidos, luego lo setea.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                bool check = false;
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        check = true;
                    }
                }

                if (check == true)
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// get: Retorna el Nombre de la Persona.
        /// set: Chequea que el Nombre que se le quiera dar a la Persona tenga caracteres válidos, luego lo setea.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                bool check = false;
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        check = true;
                    }
                }

                if (check == true)
                {
                    this.nombre = value;
                }
            }
        }
        /// <summary>
        /// get: retorna el DNI de la Persona.
        /// set: valida que el DNI y la nacionalidad coincidan. Si coinciden, lo setea, caso contario lanza excepción.
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }

            set
            {
                int aux = this.ValidarDni(this.nacionalidad, value);
                if (aux != -1)
                {
                    this.dni = aux;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }

        /// <summary>
        /// get: retorna la Nacionalidad de la Persona.
        /// set: setea la Nacionalidad de la Persona.
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
        /// set: recibe un string, el cual valida y luego setea como DNI.
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.Dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor parametrizado, permite setear nombre, apellido y nacionalidad de la persona.
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
        /// Constructor parametrizado, permite setear nombre, apellido, DNI y nacionalidad de la persona.
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
        /// Constructor parametrizado, permite setear nombre, apellido, DNI y nacionalidad de la persona.
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
            int dni = -1;

            if (dato >= 1 && dato <= 99999999)
            {
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dato < 90000000)
                        {
                            dni = dato;
                        }
                        break;
                    case ENacionalidad.Extranjero:
                        if (dato >= 90000000)
                        {
                            dni = dato;
                        }
                        break;
                    default:
                        break;
                }
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
            int.TryParse(dato, out int dni);

            dni = ValidarDni(nacionalidad, dni);

            return dni;
        }

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

    }
}

