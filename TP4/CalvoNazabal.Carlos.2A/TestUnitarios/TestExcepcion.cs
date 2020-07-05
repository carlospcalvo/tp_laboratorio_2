using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestExcepcion
    {
        [TestMethod]
        public void TestExcepcionTrackingIdRepetido()
        {
            //Arrange
            bool error = false;
            Correo aux = new Correo();
            Paquete p1 = new Paquete("Calle Falsa 123", "123-456-7890");
            Paquete p2 = new Paquete("Libertad 528", "123-456-7890");

            //Act
            try
            {
                aux += p1;
                aux += p2;
            }
            catch(TrackingIdRepetidoException)
            {
                error = true;
            }

            //Assert
            Assert.IsTrue(error);
        }
    }
}
