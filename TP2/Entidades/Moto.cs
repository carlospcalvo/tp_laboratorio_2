using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {

        #region Propiedades

        /// <summary>
        /// Retorna el tamanio del Vehiculo
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Publica los datos de la Moto
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine();
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Crea una instancia de Moto
        /// </summary>
        /// <param name="marca">Marca de la moto</param>
        /// <param name="codigo">Patente de la moto</param>
        /// <param name="color">Color de la moto</param>
        public Moto(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {
        }

        #endregion

    }
}
