using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestListaPaquetes
    {
        /// <summary>
        /// Test unitario que controla que la lista de paquetes se inicializa correctamente.
        /// </summary>
        [TestMethod]
        public void VerificarInstanciaListaPaquetes()
        {
            //Arrange

            Correo aux;

            //Act

            aux = new Correo();

            //Assert

            Assert.IsNotNull(aux.Paquetes);
        }

    }
}
