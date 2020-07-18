using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        #region Atributos

        EMarca marca;
        string chasis;
        ConsoleColor color;

        #endregion

        #region Propiedades

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected virtual ETamanio Tamanio
        {
            get
            {
                return Tamanio;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Permite castear un objeto de tipo Vehiculo a string de forma explicita
        /// </summary>
        /// <param name="p">Objeto de tipo Vehiculo a castear</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        #region Sobrecarga de Operadores

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        
        #endregion

        /// <summary>
        /// Constructor base para todas las clases derivadas de Vehiculo
        /// </summary>
        /// <param name="chasis">Numero de chasis/patente del vehiculo</param>
        /// <param name="marca">Marca del vehiculo</param>
        /// <param name="color">Color del vehiculo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        #endregion

        #region Tipos anidados

        public enum EMarca
        {
            Chevrolet, 
            Ford, 
            Renault, 
            Toyota, 
            BMW, 
            Honda
        }
        public enum ETamanio
        {
            Chico, 
            Mediano, 
            Grande
        }

        #endregion
    }
}
