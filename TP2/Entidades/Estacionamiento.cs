using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Estacionamiento
    {

        #region Atributos

        List<Vehiculo> vehiculos;
        int espacioDisponible;

        #endregion

        #region Metodos

        /// <summary>
        /// Genera una instancia de un objeto de tipo Estacionamiento.
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Genera una instancia de un objeto de tipo Estacionamiento con un espacio disponible definido.
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible del Estacionamiento</param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="tipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if (v is Camioneta)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Moto:
                        if (v is Moto)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Automovil:
                        if (v is Automovil)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                {
                    c.vehiculos.Remove(p);
                    break;
                }
            }

            return c;
        }

        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            int espacioAux = c.espacioDisponible;
            if (c.vehiculos == null)
            {
                c.vehiculos.Add(p);
            }
            else
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v == p)
                    {
                        return c;
                    }
                    espacioAux--;
                }
                if (espacioAux > 0)
                {
                    c.vehiculos.Add(p);
                }
            }
            return c;
        }

        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }

        #endregion

        #region Tipos anidados

        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #endregion
        
    }
}
