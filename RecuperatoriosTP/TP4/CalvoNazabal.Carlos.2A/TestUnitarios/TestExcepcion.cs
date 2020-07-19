using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestExcepcion
    {
        /// <summary>
        /// Test unitario que controla que se lance la excepción TrackingIdRepetidoException 
        /// al intentar agregar dos paquetes con un mismo Tracking ID
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestExcepcionTrackingIdRepetido()
        {
            Correo aux = new Correo();
            Paquete p1 = new Paquete("Calle Falsa 123", "123-456-7890");
            Paquete p2 = new Paquete("Libertad 528", "123-456-7890");

            aux += p1;
            aux += p2;

        }
    }
}
