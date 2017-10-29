using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        public enum EEstadoCuenta { AlDia,Deudor,Becado }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clase) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = clase;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clase, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clase)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// retorna la clase que toma el alumno
        /// </summary>
        protected override string ParticiparEnClase()
        {
            return "Toma clases de " + this._claseQueToma;
        }

        /// <summary>
        /// muestra los datos del alumno
        /// </summary>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// hace publico los datos del alumno
        /// </summary>
        /// <returns>retorna un string con los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// un alumno es igual a una clase solo si toma esa clase y su estado de la cuenta no es deudor
        /// </summary>
        /// <returns>retorna true si son iguales o false caso contrario</returns>
        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            return alumno._claseQueToma == clase && alumno._estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// un alumno es distinto a la clase si no toma esa clase
        /// </summary>
        /// <returns>retorna true si es distinto o false caso con contrario</returns>
        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            return alumno._claseQueToma != clase;
        }
    }
}
