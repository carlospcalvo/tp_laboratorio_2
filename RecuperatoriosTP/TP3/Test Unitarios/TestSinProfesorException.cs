using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Abstractas;
using Clases_Instanciables;
using Archivos;

namespace Test_Unitarios
{
    [TestClass]
    public class TestSinProfesorException
    {
        /// <summary>
        /// Verifica que lance la excepcion SinProfesorException al querer crear un objeto Jornada  
        /// sin haber profesores que tengan el atributo EClases.Programacion
        /// </summary>
        [TestMethod]
        public void VerificarLanzamientoSinProfesorException_00()
        {
            //Arrange

            Universidad uni = new Universidad();
            string error = "La excepcion no fue lanzada.";

            //Act

            try
            {
                uni += Universidad.EClases.Programacion;
            }
            catch (SinProfesorException e)
            {
                error = e.Message; 
            }

            //Assert

            Assert.AreEqual("No hay profesor para la clase.", error);

        }

        /// <summary>
        /// Verifica que lance la excepcion SinProfesorException al querer crear un objeto Jornada  
        /// sin haber profesores que tengan el atributo EClases.Laboratorio
        /// </summary>
        [TestMethod]
        public void VerificarLanzamientoSinProfesorException_01()
        {
            //Arrange

            Universidad uni = new Universidad();
            string error = "La excepcion no fue lanzada.";

            //Act

            try
            {
                uni += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                error = e.Message;
            }

            //Assert

            Assert.AreEqual("No hay profesor para la clase.", error);

        }

        /// <summary>
        /// Verifica que lance la excepcion SinProfesorException al querer crear un objeto Jornada  
        /// sin haber profesores que tengan el atributo EClases.Legislacion
        /// </summary>
        [TestMethod]
        public void VerificarLanzamientoSinProfesorException_02()
        {
            //Arrange

            Universidad uni = new Universidad();
            string error = "La excepcion no fue lanzada.";

            //Act
            
            try
            {
                uni += Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                error = e.Message;
            }

            //Assert

            Assert.AreEqual("No hay profesor para la clase.", error);

        }

        /// <summary>
        /// Verifica que lance la excepcion SinProfesorException al querer crear un objeto Jornada  
        /// sin haber profesores que tengan el atributo EClases.SPD
        /// </summary>
        [TestMethod]
        public void VerificarLanzamientoSinProfesorException_03()
        {
            //Arrange

            Universidad uni = new Universidad();
            string error = "La excepcion no fue lanzada.";

            //Act

            try
            {
                uni += Universidad.EClases.SPD;
            }
            catch (SinProfesorException e)
            {
                error = e.Message;
            }

            //Assert

            Assert.AreEqual("No hay profesor para la clase.", error);

        }
    }
}
