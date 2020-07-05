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

        public event DelegadoEstado InformaEstado;

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

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete aux = (Paquete) elemento;
            return string.Format("{0} para {1}", aux.TrackingID, aux.DireccionEntrega);
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public void MockCicloDeVida()
        {
            int aux = 0;
            do
            {
                //pauso el hilo para simular el tiempo de carga/procesamiento/envío
                Thread.Sleep(4000);
                switch (aux)
                {
                    case 0:
                        this.estado = EEstado.Ingresado;
                        break;
                    case 1:
                        this.estado = EEstado.EnViaje;
                        break;
                    case 2:
                        this.estado = EEstado.Entregado;
                        break;
                    default:
                        break;
                }
                aux++;
                //lanzo el evento que notifica que cambió el estado del paquete
                this.InformaEstado((object)this, EventArgs.Empty);
            } while (this.estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el paquete a la base de datos.", ex);
            }
        }

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
    }
}
