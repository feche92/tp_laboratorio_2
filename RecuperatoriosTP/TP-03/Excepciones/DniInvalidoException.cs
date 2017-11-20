using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private static string mensajeBase;

        static DniInvalidoException()
        {
            DniInvalidoException.mensajeBase = "dni invalido. ";
        }

        public DniInvalidoException(Exception e) : base(mensajeBase,e)
        {
        }

        public DniInvalidoException(string mensaje) : base(DniInvalidoException.mensajeBase + mensaje)
        {
        }

        public DniInvalidoException(string mensaje, Exception e) : base(DniInvalidoException.mensajeBase + mensaje, e)
        {
        }


    }
}
