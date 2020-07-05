using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }

            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            List<Paquete> aux = ((Correo) elementos).paquetes;
            
            foreach(Paquete item in aux)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString()));
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            
            foreach (Paquete item in c.paquetes)
            {
                if (p == item)
                {
                    throw new TrackingIdRepetidoException(p.TrackingID);
                }
            }

            try
            {
                //agrego el paquete
                c.paquetes.Add(p);
                //creo el hilo con el "puntero" de la función 
                Thread hilo = new Thread(new ThreadStart(p.MockCicloDeVida));
                //inicio el hilo
                hilo.Start();
                //agrego el hilo a mockPaquetes
                c.mockPaquetes.Add(hilo);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }

            return c;
        }

        public void FinEntregas()
        {
            //recorro la lista de hilos
            foreach(Thread hilo in mockPaquetes)
            {
                //si el hilo está abierto, lo cierro
                if(hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }
    }
}
