using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _istructor;

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._istructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._istructor; }
            set { this._istructor = value; }
        }

        /// <summary>
        /// hace publicos los datos del alumno
        /// </summary>
        /// <returns>retorna un string con los datos del alumno</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Clase de " + this._clase + " por " + this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<-------------------------------------------------------------->");
            return sb.ToString();
        }

        /// <summary>
        /// una jornada es igual a un alumno solo si ese alumno participa en la jornada
        /// </summary>
        /// <returns>retorna true si son iguales o false caso contrario</returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            bool retorno = false;
            for (int i = 0; i < jornada._alumnos.Count; i++)
            {
                if (jornada._alumnos[i].Equals(alumno))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// una jornada es distinto a un alumno solo si ese alumno no participa de dicha jornada
        /// </summary>
        /// <returns>retorna true si son distintos o false caso contrario</returns>
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        /// <summary>
        /// agrega un alumno a una jornada validando que no este previamente cargado
        /// </summary>
        /// <returns>retorna la jornada con el alumno agregado o no si ya estaba cargado</returns>
        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if (jornada != alumno)
            {
                jornada._alumnos.Add(alumno);
            }
            else
                throw new AlumnoRepetidoException();
            return jornada;
        }

        /// <summary>
        /// guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">datos de la jornada a ser guardada</param>
        /// <returns>retorna true si se guardo bien o false si hubo algun error</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            if (texto.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString()))
                return true;
            else
                return false;            
        }

        /// <summary>
        /// lee los datos de la jornada previamente guardados
        /// </summary>
        /// <returns>retorna un string con los datos de la jornada si estuvo todo bien o un string vacio si hubo algun error</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string datos;
            texto.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out datos);
            return datos;
        }




    }
}
