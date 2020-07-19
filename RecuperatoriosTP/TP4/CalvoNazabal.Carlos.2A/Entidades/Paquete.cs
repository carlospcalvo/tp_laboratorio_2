using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades
{
    

    public class Paquete : IMostrar<Paquete>
    {
        string direccionEntrega;
        EEstado estado;
        string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoExcepcion(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        public event DelegadoExcepcion InformaExcepcion;

        /// <summary>
        /// get, set: retorna o asigna la dirección de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }

            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// get, set: retorna o asigna el estado del paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// get, set: retorna o asigna el Tracking ID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Constructor parametrizado: inicializa un objeto Paquete definiendo su dirección de entrega y Tracking ID
        /// </summary>
        /// <param name="direccionEntrega"> Dirección de entrega del paquete </param>
        /// <param name="trackingID"> Tracking ID del paquete </param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Publica los datos de un paquete
        /// </summary>
        /// <param name="elemento"> Paquete que se quiere mostrar </param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete aux = (Paquete) elemento;
            return string.Format("{0} para {1}", aux.TrackingID, aux.DireccionEntrega);
        }

        /// <summary>
        /// Sobrecarga del método ToString() que devuelve los datos de un paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Compara dos paquetes, los cuales son iguales si tienen el mismo Tracking ID
        /// </summary>
        /// <param name="p1"> Paquete A </param>
        /// <param name="p2"> Paquete B </param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// Compara dos paquetes, los cuales son distintos si tienen Tracking ID distinto
        /// </summary>
        /// <param name="p1"> Paquete A </param>
        /// <param name="p2"> Paquete B </param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Método que simula el movimiento de un paquete a través de distintas etapas.
        /// Una vez que el paquete es "entregado", éste se agrega a la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            try
            {
                int aux = 0;

                while (aux <= 2)
                {
                    this.Estado = (EEstado)aux;
                    this.InformaEstado.Invoke(this, EventArgs.Empty);
                    Thread.Sleep(4000);
                    aux++;
                }
            
                PaqueteDAO.Insertar(this);
            }
            catch (Exception)
            {
                this.InformaExcepcion.Invoke(this, EventArgs.Empty);
            }
        }

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
    }
}
