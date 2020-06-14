using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Clases_Abstractas;
using Clases_Instanciables;
using Archivos;

namespace Test_Unitarios
{
    [TestClass]
    public class TestColecciones
    {
        /// <summary>
        /// Valida si la coleccion de objetos Alumno de un objeto Universidad se inicializa correctamente con su constructor
        /// </summary>
        [TestMethod]
        public void VerificarInstanciaColeccionAlumnos()
        {
            //Arrange

            Universidad uni = null;

            //Act

            uni = new Universidad();

            //Assert

            Assert.IsNotNull(uni.Alumnos);
        }

        /// <summary>
        /// Valida si la coleccion de objetos Profesor de un objeto Universidad se inicializa correctamente con su constructor
        /// </summary>
        [TestMethod]
        public void VerificarInstanciaColeccionProfesores()
        {
            //Arrange

            Universidad uni = null;

            //Act

            uni = new Universidad();

            //Assert

            Assert.IsNotNull(uni.Profesores);
        }

        /// <summary>
        /// Valida si la coleccion de objetos Jornada de un objeto Universidad se inicializa correctamente con su constructor
        /// </summary>
        [TestMethod]
        public void VerificarInstanciaColeccionJornadas()
        {
            //Arrange

            Universidad uni = null;

            //Act

            uni = new Universidad();

            //Assert

            Assert.IsNotNull(uni.Jornadas);
        }

    }
}
