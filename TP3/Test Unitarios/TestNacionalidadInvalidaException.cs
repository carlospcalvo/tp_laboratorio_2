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
    public class TestNacionalidadInvalidaException
    {
        /// <summary>
        /// Verifica que al inicializar un Alumno con DNI menor a 90 millones con nacionalidad extranjera lance la excepcion correspondiente
        /// </summary>
        [TestMethod]
        public void VerificarLanzamientoNacionalidadInvalidaException_00()
        {
            //Arrange

            Alumno aux = new Alumno();
            string error = "No se lanzo la excepcion.";

            //Act
            try
            {
                aux = new Alumno(2, "Braian", "Martinez", "12234458",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            }
            catch(NacionalidadInvalidaException e)
            {
                error = e.Message;
            }

            //Assert

            Assert.AreEqual("La nacionalidad no se condice con el numero de DNI.", error);


        }

        /// <summary>
        /// Verifica que al inicializar un Alumno con DNI mayor a 90 millones con nacionalidad argentina lance la excepcion correspondiente
        /// </summary>
        [TestMethod]
        public void VerificarLanzamientoNacionalidadInvalidaException_01()
        {
            //Arrange

            Alumno aux = new Alumno();
            string error = "No se lanzo la excepcion.";

            //Act
            try
            {
                aux = new Alumno(2, "Braian", "Martinez", "90234458",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            }
            catch (NacionalidadInvalidaException e)
            {
                error = e.Message;
            }

            //Assert

            Assert.AreEqual("La nacionalidad no se condice con el numero de DNI.", error);

        }

        /// <summary>
        /// Verifica que al inicializar un Profesor con DNI mayor a 90 millones con nacionalidad argentina lance la excepcion correspondiente
        /// </summary>
        [TestMethod]
        public void VerificarLanzamientoNacionalidadInvalidaException_02()
        {
            //Arrange

            Profesor aux;
            string error = "No se lanzo la excepcion.";

            //Act
            try
            {
                aux = new Profesor(3, "Pablo", "Hernandez", "90234458", Persona.ENacionalidad.Argentino);
            }
            catch (NacionalidadInvalidaException e)
            {
                error = e.Message;
            }

            //Assert

            Assert.AreEqual("La nacionalidad no se condice con el numero de DNI.", error);

        }

        /// <summary>
        /// Verifica que al inicializar un Profesor con DNI mayor a 90 millones con nacionalidad argentina lance la excepcion correspondiente
        /// </summary>
        [TestMethod]
        public void VerificarLanzamientoNacionalidadInvalidaException_03()
        {
            //Arrange

            Profesor aux;
            string error = "No se lanzo la excepcion.";

            //Act
            try
            {
                aux = new Profesor(3, "Pablo", "Hernandez", "25234458", Persona.ENacionalidad.Extranjero);
            }
            catch (NacionalidadInvalidaException e)
            {
                error = e.Message;
            }

            //Assert

            Assert.AreEqual("La nacionalidad no se condice con el numero de DNI.", error);

        }
    }
}
