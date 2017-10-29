using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino,Extranjero }

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = Persona.ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = Persona.ValidarDni(this._nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = Persona.ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set { this._dni = Persona.ValidarDni(this._nacionalidad, value); }
        }

        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Muestra los datos de la persona
        /// </summary>
        /// <returns>Retorna un string con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre completo: " + this._apellido + ", " + this._nombre);
            sb.AppendLine("Nacionalidad: " + this._nacionalidad);
            sb.AppendLine("DNI: " + this._dni);
            return sb.ToString();
        }

        /// <summary>
        /// Validará que el dni este desntro de los rangos permitidos
        /// </summary>
        /// <param name="dato">dni numerico a validar</param>
        /// <returns>retorna el dni validado o 0 en case de error</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException();
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;

        }

        /// <summary>
        /// validará que el dni sea numerico y luego llamara a la validacion numerica
        /// </summary>
        /// <param name="dato">string del dni a validad</param>
        /// <returns>retorna el dni numerico validado o 0 en case de error</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;
            try
            {
                dni = int.Parse(dato);
            }
            catch (OverflowException e)
            {
                throw new DniInvalidoException("dni muy alto", e);
            }
            catch (FormatException e)
            {
                throw new DniInvalidoException("Error de formato", e);
            }
            return Persona.ValidarDni(nacionalidad, dni);
            
        }

        /// <summary>
        /// valida que el nombre o apellido tengo solo caracteres correctos(a-z o A-Z)
        /// </summary>
        /// <param name="dato">nombre o apellido a validar</param>
        /// <returns>retorna el string validado o un string vacio en case de error</returns>
        private static string ValidarNombreApellido(string dato)
        {
            bool bandera = false;
            foreach (char item in dato)
            {
                if (!char.IsLetter(item))
                {
                    bandera = true;
                    break;
                }
                    
            }
            if (bandera == true)
                dato = "";
            return dato;
        }




    }
}
