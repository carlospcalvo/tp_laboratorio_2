using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {

        #region Atributos

        ETipo tipo;

        #endregion

        #region Propiedades

        /// <summary>
        /// Retorna el tamanio del Vehiculo
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Genera una instancia de un objeto de tipo Automovil. Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">Marca del Automovil</param>
        /// <param name="chasis">Numero de chasis/patente del Automovil</param>
        /// <param name="color">Color del Automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.Monovolumen;
        }

        /// <summary>
        ///  Genera una instancia de un objeto de tipo Automovil, pudiendo definir el tipo.
        /// </summary>
        /// <param name="marca">Marca del Automovil</param>
        /// <param name="chasis">Numero de chasis/patente del Automovil</param>
        /// <param name="color">Color del Automovil</param>
        /// <param name="tipo">Tipo de Automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Publica los datos del Automovil
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

        #region Tipos Anidados

        public enum ETipo
        {
            Monovolumen,
            Sedan
        }

        #endregion
    }
}
