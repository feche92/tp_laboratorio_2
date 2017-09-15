using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1
{
    class Numero
    {
        private double numero;
        /// <summary>
        /// retorna el atributo numero del objeto Numero
        /// </summary>
        /// <returns></returns>
        public double GetNumero()
        {
            return this.numero;
        }
        /// <summary>
        /// constructor por defecto del objeto Numero
        /// </summary>
        public Numero() : this(0)
        {
        }
        /// <summary>
        /// crea una nueva instancia de la clase Numero
        /// </summary>
        /// <param name="numero">le da un valor inicial al atributo numero</param>                
        public Numero(string numero)
        {
            this.SetNumero(numero);
        }
        /// <summary>
        /// crea una nueva instancia de la clase Numero
        /// </summary>
        /// <param name="numero">le da un valor inicial al atributo numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// valida que el string sea un numero valido
        /// </summary>
        /// <param name="numero">string a validar</param>
        /// <returns>retorna el numero si es valido o 0 si no lo es</returns>
        private static double ValidarNumero(string numero)
        {
            double valorDevuelto = 0;
            if (double.TryParse(numero, out valorDevuelto))
                return valorDevuelto;
            else
                return valorDevuelto;
        }
                    
        private void SetNumero(string numero)
        {
            this.numero = Numero.ValidarNumero(numero);
        }
    }
}
