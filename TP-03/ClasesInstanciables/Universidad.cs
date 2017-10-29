using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases { Laboratorio, Legislacion, Programacion, SPD }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i >= this.jornada.Count || i < 0)
                    return null;
                else
                    return this.jornada[i];
            }
            set
            {
                if (i >= 0 && i < this.jornada.Count)
                    this.jornada[i] = value;
                else if (i == this.jornada.Count)
                    this.jornada.Add(value);
            }

            
        }

        /// <summary>
        /// muestra los datos de la jornadas de la universidad
        /// </summary>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jornadas:");
            for (int i = 0; i < gim.jornada.Count; i++)
            {
                sb.Append(gim[i].ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// hace publicos los datos de la universidad
        /// </summary>
        /// <returns>retorna un string con los datos de la universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// una universidad es igual a un alumno solo si ese alumno esta inscripto en esta universidad
        /// </summary>
        /// <returns>retorna true si son iguales o false caso contrario</returns>
        public static bool operator ==(Universidad gim, Alumno alumno)
        {
            bool retorno = false;
            for (int i = 0; i < gim.alumnos.Count; i++)
            {
                if (gim.alumnos[i].Equals(alumno))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// una universidad es distinto a un alumno solo si ese alumno no esta inscripto en la universidad
        /// </summary>
        /// <returns>retorna true si son distinto o false caso contrario</returns>
        public static bool operator !=(Universidad gim, Alumno alumno)
        {
            return !(gim == alumno);
        }

        /// <summary>
        /// una universidad es igual a un profesor solo si ese profesor esta inscipto en la universidad
        /// </summary>
        /// <returns>retorna true si son iguales o false caso contrario</returns>
        public static bool operator ==(Universidad gim, Profesor profesor)
        {
            bool retorno = false;
            for (int i = 0; i < gim.profesores.Count; i++)
            {
                if (gim.profesores[i].Equals(profesor))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// una universidad es distinto a un profesor solo si ese profesor no esta inscripto en la universidad
        /// </summary>
        /// <returns>retorna true si son distinto o false caso contrario</returns>
        public static bool operator !=(Universidad gim, Profesor profesor)
        {
            return !(gim == profesor);
        }

        /// <summary>
        /// la igualacion entre una universidad y clase retorna el primer profesor capaz de dar esa clase
        /// </summary>
        /// <returns>retorna el primer profesor de dar esa clase o si no hay retorna un profesor sin datos</returns>
        public static Profesor operator ==(Universidad gim, EClases clase)
        {
            Profesor aux = new Profesor();
            bool bandera = false;
            for (int i = 0; i < gim.profesores.Count; i++)
            {
                if (gim.profesores[i] == clase)
                {
                    aux = gim.profesores[i];
                    bandera = true;
                    break;
                }
            }
            if (bandera == false)
                throw new SinProfesorException();
            return aux;
        }

        /// <summary>
        /// el distinto entre una universidad y clase retorna el primer profesor que no pueda dar esa clase
        /// </summary>
        public static Profesor operator !=(Universidad gim, EClases clase)
        {
            Profesor aux = new Profesor();
            bool bandera = false;
            for (int i = 0; i < gim.profesores.Count; i++)
            {
                if (gim.profesores[i] != clase)
                {
                    aux = gim.profesores[i];
                    bandera = true;
                    break;
                }
            }
            if (bandera == false)
                throw new SinProfesorException();
            return aux;

        }

        /// <summary>
        /// inscribe un alumno a la universidad validando que no este previamente cargado
        /// </summary>
        /// <returns>retorna la universidad con el alumno cargado o no si ya estaba</returns>
        public static Universidad operator +(Universidad gim, Alumno alumno)
        {
            if (gim != alumno)
                gim.alumnos.Add(alumno);
            else
                throw new AlumnoRepetidoException();
            return gim;
        }

        /// <summary>
        /// inscribe un profesor a la universidad validando que no este previamente cargado
        /// </summary>
        /// <returns>retorna la universidad con el profesor cargado o no si ya estaba</returns>
        public static Universidad operator +(Universidad gim, Profesor profesor)
        {
            if (gim != profesor)
                gim.profesores.Add(profesor);
            return gim;
        }

        /// <summary>
        /// agrega una nueva jornada a la universidad validando que halla un profesor que puedar dar dicha clase y agregando alumnos a la jornada que esten anotados en dicha clase
        /// </summary>
        /// <returns>retorna una universidad con la jornada cargada si estuvo todo bien o la universidad sin la jornada por no haber un profesor que de dicha clase</returns>
        public static Universidad operator +(Universidad gim, EClases clase)
        {
            Profesor aux = (gim == clase);
            if (aux.DNI!=0)
            {
                Jornada jornada = new Jornada(clase, aux);
                for (int i = 0; i < gim.alumnos.Count; i++)
                {
                    if(gim.alumnos[i]==clase)
                    {
                        jornada += gim.alumnos[i];
                    }
                }
                gim.jornada.Add(jornada);
            }
            return gim;
        }

        /// <summary>
        /// guarda todos los datos de la universidad en un archivo xml
        /// </summary>
        /// <param name="gim">universidad a ser guardada</param>
        /// <returns>retorna true si pudo guardar la universidad o false en caso de error</returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            if (xml.guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", gim))
                return true;
            else
                return false;           
        }

        /// <summary>
        /// lee los datos de la universidad previamente guardados
        /// </summary>
        /// <returns>retorna una universidad con todos los datos guardados si estuvo todo bien o una universidad vacia en caso de error</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad universidad = new Universidad();
            xml.leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out universidad);
            return universidad;
        }

    }
}
