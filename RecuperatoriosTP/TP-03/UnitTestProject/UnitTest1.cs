using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;
using Archivos;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExcecion1()
        {
            Universidad universidad = new Universidad();
            Alumno alumnoUno = new Alumno(1,"Federico","Ivagaza","36762678",Persona.ENacionalidad.Argentino,Universidad.EClases.Laboratorio);
            Alumno alumnoDos = new Alumno(2, "Sebastian", "Perez", "36762678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            universidad += alumnoUno;
            try
            {
                universidad += alumnoDos;
                Assert.Fail("Deberia avisar que el alumno esta repetido");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void TestException2()
        {
            try
            {
                Alumno alumno = new Alumno(1, "Pablo", "Perez", "11111", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
                Assert.Fail("Deberia avisar que la nacionalidad es invalida");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

        }

        [TestMethod]
        public void ValidarNumeros()
        {
            try
            {
                Profesor profesor = new Profesor(1, "German", "Scarafilo", "4545f55", Persona.ENacionalidad.Argentino);
                Assert.Fail("Deberia avisar que el dni es invalido");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void ValidarNulos()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}
