using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {

        private int legajo;

        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// dos universitarios son iguales solo si su legajo o dni son iguales y si son del mismo tipo
        /// </summary>
        /// <returns>retorna true si son iguales o false caso contrario</returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario) && this==(Universitario)obj;
        }

        public static bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {
            return universitarioUno.DNI == universitarioDos.DNI || universitarioUno.legajo == universitarioDos.legajo;
        }

        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {
            return !(universitarioUno == universitarioDos);
        }

        /// <summary>
        /// muestra los datos del universitario
        /// </summary>
        /// <returns>retorna un string con los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("Legajo: " + this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// retorna las clases que toma o da el universitario
        /// </summary>
        protected abstract string ParticiparEnClase();

    }
}
