using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestListaPaquetes
    {
        [TestMethod]
        public void VerificarInstanciaListaPaquetes()
        {
            //Arrange

            Correo aux = null;

            //Act

            aux = new Correo();

            //Assert

            Assert.IsNotNull(aux.Paquetes);
        }

    }
}
