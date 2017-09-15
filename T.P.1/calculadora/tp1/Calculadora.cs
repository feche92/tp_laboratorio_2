using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1
{
    class Calculadora
    {
        /// <summary>
        /// realiza la operacion correspondiente con los numeros y el operador que se le pase como parametros
        /// </summary>
        /// <param name="numero1">primera instancia de la clase Numero</param>
        /// <param name="numero2">segunda instancia de la clase Numero</param>
        /// <param name="operador">string del operador</param>
        /// <returns>retorna el resultado de dicha operacion</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double valor = 0;
            operador = Calculadora.ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    valor = numero1.GetNumero() + numero2.GetNumero();
                    break;
                case "-":
                    valor = numero1.GetNumero() - numero2.GetNumero();
                    break;
                case "/":
                    if (numero2.GetNumero() == 0)
                        valor = 0;
                    else
                        valor = numero1.GetNumero() / numero2.GetNumero();
                    break;
                case "*":
                    valor = numero1.GetNumero() * numero2.GetNumero();
                    break;
            }

            return valor;
        }
        /// <summary>
        /// valida que el operador que reciba como parametro sea valido
        /// </summary>
        /// <param name="operador">string del operador</param>
        /// <returns>retorna el operador correspondiente si es valido o "+" si es invalido</returns>
        private static string ValidarOperador(string operador)
        {
            string valor = "+";
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
                valor = operador;
            return valor;
        }
    }
}

