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

        /// <summary>
        /// get, set: Reorna o asigna la lista de paquetes
        /// </summary>
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

        /// <summary>
        /// Constructor por defecto: Inicializa la lista de paquetes y la lista de hilos
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Hace públicos los datos de cada paquete 
        /// </summary>
        /// <param name="elementos"> Aquello cuya lista de paquetes se quiere mostrar </param>
        /// <returns></returns>
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

        /// <summary>
        /// Sobrecarga del método ToString() que devuelve los datos de los paquetes del correo.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Permite agregar un paquete a la lista de paquetes de correos
        /// </summary>
        /// <param name="c"> Correo al que se quiere agregar el paquete </param>
        /// <param name="p"> Pquete que se quiere agregar </param>
        /// <returns></returns>
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
            catch(Exception)
            {
            }

            return c;
        }

        /// <summary>
        /// Al cerrar el formulario, cierra los hilos del correo.
        /// </summary>
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
