using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        #region Propiedades

        /// <summary>
        /// Retorna el tamanio del Vehiculo
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Genera una instancia de un objeto de tipo Camioneta.
        /// </summary>
        /// <param name="marca">Marca de la Camioneta</param>
        /// <param name="chasis">Numero de chasis/patente de la Camioneta</param>
        /// <param name="color">Color de la Camioneta</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Publica los datos de la Camioneta
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    
    }
}
